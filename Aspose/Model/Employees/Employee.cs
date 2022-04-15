namespace Aspose.Model.Employees
{
	public sealed class Employee : EmployeeBase
	{
		protected override decimal BonusRate { get => 3; }
		protected override decimal BonusLimit { get => 30; }
		
		public override List<IEmployee> Staff
		{ 
			get => base.Staff;
			set
			{
				if (value != null && GetType() == typeof(Employee))
					throw new ArgumentException(Errors.EMPLOYEE_CANNOT_HAVE_STAFF);
				base.Staff = value;
			}
		}
		public override IEmployee Supervisor
		{
			get => base.Supervisor;
			set
			{
				if (value.GetType() == typeof(Employee))
					throw new ArgumentException(Errors.EMPLOYEE_CANNOT_BE_SUPERVISOR);
				base.Supervisor = value;
			}
		}
	}
}
