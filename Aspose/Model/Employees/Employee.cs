namespace Aspose.Model.Employees
{
	public sealed class Employee : IEmployee
	{
		private IEmployee? _supervisor;
		private IStaff _staff;
		private decimal _cachedSalary;
		private DateTime _cachedDate;

		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime HiringDate { get; set; }
		public IStaff Staff { get => _staff; }
		public IEmployee? Supervisor { get => _supervisor; }
		public ISalary Salary { get; set; }

		public Employee(int id, string name, DateTime hiringDate, ISalary salary)
		{
			Id = id;
			Name = name;
			HiringDate = hiringDate;
			Salary = salary;
			_staff = new Staff();
		}

		/// <summary>
		/// Add staff to a current employee and set him as a supervisor for all employees in that staff
		/// </summary>
		/// <param name="staff">Employees list (staff)</param>
		/// <exception cref="ArgumentException">Throws an ArgumentException if your trying to add staff to an employee with type of Employee
		/// cause instance of an Employee cannot have a staff</exception>
		/// <exception cref="ArgumentNullException">Throws an ArgumentNullException if staff param is null</exception>
		public void SetStaff(IStaff staff)
		{
			if (!Salary.CanHaveStaff)
				throw new ArgumentException(Errors.EMPLOYEE_CANNOT_HAVE_STAFF);

			if (staff == null)
				throw new ArgumentNullException(nameof(staff));

			foreach (var employee in staff)
				employee.SetSupervisor(this);
		}

		/// <summary>
		/// Set supervisor to a current employee and add this employee to supervisor staff
		/// </summary>
		/// <param name="supervisor">Supervisor for current employee</param>
		/// <exception cref="ArgumentException">Throws ArgumentException if your trying to set an instance of Employee class as supervisor
		/// cause Employee can't be a supervisor. Also throws ArgumentException if your trying to set as a supervisor the instance by themself</exception>
		public void SetSupervisor(IEmployee? supervisor)
		{
			if (supervisor == null)
			{
				if (_supervisor == null) return;
				_supervisor.Staff.Remove(this);
				_supervisor = null;
			}
			else
			{
				if (!supervisor.Salary.CanHaveStaff)
					throw new ArgumentException(Errors.EMPLOYEE_CANNOT_BE_SUPERVISOR);
				if (Equals(supervisor))
					throw new ArgumentException(Errors.EMPLOYEE_CANNOT_SUPERVISE_THEMSELF);
				if (supervisor.Staff.Find(this) == -1) supervisor.Staff.Add(this, supervisor);
				_supervisor = supervisor;
			}
		}


		public decimal GetTotalSalaryAtDate(DateTime date)
		{
			if (_cachedDate == date.Date)
				return _cachedSalary;

			var years = new DateTime(
				(date.Date - HiringDate.Date)
				.Ticks).Year - 1;
			var bonus = years * Salary.YearBonusRate;
			if (bonus > Salary.TotalBonusLimit) bonus = Salary.TotalBonusLimit;
			var total = Salary.BaseSalary * (bonus / 100 + 1);

			switch(Salary.StaffBonusType)
			{
				case StaffBonusType.None: break;
				case StaffBonusType.Level1:
					foreach (var employee in Staff)
						total += employee.GetTotalSalaryAtDate(date) * Salary.StaffBonusRate / 100;
					break;
				case StaffBonusType.AllLevels:

					var queue = new Queue<IEmployee>();
					var list = new List<IEmployee>();
					GetTotalStaff(list, this);
					var data = list.Where(e => e.Staff.Count() == 0).ToList();
					FillQueue(data, queue);

					while (queue.Count > 0)
					{
						var employee = queue.Dequeue();
						total += employee.GetTotalSalaryAtDate(date) * Salary.StaffBonusRate / 100;
					}
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(Salary.StaffBonusType));
			}

			total = Math.Round(total, 2);
			
			_cachedDate = date.Date;
			_cachedSalary = total;

			return _cachedSalary;
		}

		public void GetTotalStaff(IList<IEmployee> list, IEmployee employee)
		{
			foreach (var e in employee.Staff)
			{
				list.Add(e);
				GetTotalStaff(list, e);
			}
		}

		public void FillQueue(IList<IEmployee> level, Queue<IEmployee> queue)
		{
			var next = new List<IEmployee>();
			foreach (var e in level)
			{
				queue.Enqueue(e);
				if (e.Supervisor != null)
					if (!next.Contains(e.Supervisor))
						next.Add(e.Supervisor);
			}
			if (next.Count > 0)		
				FillQueue(next, queue);
		}


	}
}
