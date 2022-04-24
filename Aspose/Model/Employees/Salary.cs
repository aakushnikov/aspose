namespace Aspose.Model.Employees
{
	public sealed class Salary : ISalary
	{
		bool _canHaveStaff;
		public string Position { get; set; }
		public decimal BaseSalary { get; set; }
		public decimal YearBonusRate { get; set; }
		public decimal TotalBonusLimit { get; set; }
		public StaffBonusType StaffBonusType { get; set; }
		public decimal StaffBonusRate { get; set; }
		public bool CanHaveStaff { get => _canHaveStaff; }

		public Salary(string position, decimal baseSalary, decimal yearBonusRate, decimal totalBonusLimit, decimal staffBonusRate, StaffBonusType staffBonusType, bool canHaveStaff)
		{
			Position = position;
			BaseSalary = baseSalary;
			YearBonusRate = yearBonusRate;
			TotalBonusLimit = totalBonusLimit;
			StaffBonusRate = staffBonusRate;
			StaffBonusType = staffBonusType;

			_canHaveStaff = canHaveStaff;
		}
	}
}
