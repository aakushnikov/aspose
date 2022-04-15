namespace Aspose.Model.Employees
{
	public abstract class EmployeeBase : IEmployee
	{
		protected abstract decimal BonusRate { get; }
		protected abstract decimal BonusLimit { get; }

		public virtual string Id { get; set; }
		public virtual string Name { get; set; }
		public virtual decimal Salary { get; set; }
		public virtual DateTime HiringDate { get; set; }
		public virtual List<IEmployee> Staff { get; set; }
		public virtual IEmployee Supervisor { get; set; }


		public virtual decimal GetTotalSalaryAtDate(DateTime date)
		{
			var years = new DateTime(
				(date.Date - HiringDate.Date)
				.Ticks).Year - 1;
			var bonus = years * BonusRate;
			if (bonus > BonusLimit) bonus = BonusLimit;
			var total = Salary * (bonus / 100 + 1);
			return Math.Round(total, 2);
		}

		/*
		public virtual void AddEmployeeToStaff(IEmployee employee)
		{
			if (Staff == null)
				Staff = new List<IEmployee>();
			employee.Supervisor = this;
			var e = Staff.Find(x => x.Id == employee.Id);
			if (e != null) throw new ApplicationException();
			Staff.Add(employee);
		}

		public virtual void RemoveEmployeeFromStaff(IEmployee employee)
		{

		}
		*/
	}
}
