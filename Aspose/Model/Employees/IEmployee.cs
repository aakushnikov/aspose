namespace Aspose.Model.Employees
{
	public interface IEmployee
	{
		string Id { get; set; }
		string Name { get; set; }
		decimal Salary { get; set; }
		DateTime HiringDate { get; set; }
		List<IEmployee> Staff { get; set; }
		IEmployee Supervisor { get; set; }

		decimal GetTotalSalaryAtDate(DateTime date);
	}
}
