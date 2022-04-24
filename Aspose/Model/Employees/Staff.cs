namespace Aspose.Model.Employees
{
	public sealed partial class Staff : IStaff
	{
		private List<IEmployee> _list = new List<IEmployee>();
		public Staff()
		{
			_list = new List<IEmployee>();
			
			_current = 0; // IEnumerator service variable. See Staff.Secondary.cs
		}

		public void Add(IEmployee employee, IEmployee? supervisor)
		{
			if (employee.Supervisor != null && !employee.Supervisor.Equals(supervisor))
				employee.SetSupervisor(supervisor);
			_list.Add(employee);
		}

		public void Remove(IEmployee employee)
		{
			var index = _list.IndexOf(employee);
			if (index == -1) return;
			if (employee.Staff.Count() > 0)
				throw new InvalidOperationException(Errors.CANNOT_REMOVE_EMPLOYEE_WITH_STAFF);
			_list.RemoveAt(index);
		}

		public void Remove(int id)
		{
			var employee = _list.Find(e => e.Id == id);
			if (employee == null) return;
			Remove(employee);
		}

		public int Find(IEmployee employee)
		{
			var index = _list.IndexOf(employee);
			return index;
		}

		public int Find(int id)
		{
			var employee = _list.Find(e => e.Id == id);
			if (employee == null) return -1;	
			return _list.IndexOf(employee);
		}
	}
}
