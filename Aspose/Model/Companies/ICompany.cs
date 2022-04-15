using Aspose.Model.Employees;

namespace Aspose.Model.Companies
{
	public interface ICompany
	{
		string Name { get; set; }
		List<IEmployee> Employees { get; set; }
		decimal GetTotalSalaryAtDate(DateTime date);
	}
}
