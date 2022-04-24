namespace Aspose.Model.Employees
{
	public interface ISalary
	{
		string Position { get; set; }
		decimal BaseSalary { get; set; }
		decimal TotalBonusLimit { get; set; }
		decimal YearBonusRate { get; set; }
		decimal StaffBonusRate { get; set; }
		StaffBonusType StaffBonusType { get; set; }
		bool CanHaveStaff { get; }
	}
}
