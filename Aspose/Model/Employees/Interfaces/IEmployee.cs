namespace Aspose.Model.Employees
{
	public interface IEmployee
	{
		int Id { get; set; }
		string Name { get; set; }
		ISalary Salary { get; set; }
		DateTime HiringDate { get; set; }
		IStaff Staff { get; }
		IEmployee? Supervisor { get; }

		void SetStaff(IStaff staff);
		void SetSupervisor(IEmployee? employee);
		decimal GetTotalSalaryAtDate(DateTime date);
	}
}
