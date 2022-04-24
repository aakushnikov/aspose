using Aspose.Model.Employees;

namespace Aspose.Model.Companies
{
	public abstract class CompanyBase : ICompany
	{
		public string Name { get; set; }
		public List<IEmployee> Employees { get; set; }

		protected CompanyBase()
		{
			Employees = new List<IEmployee>();
		}

		public virtual decimal GetTotalSalaryAtDate(DateTime date)
		{
			decimal result = 0;
			foreach(var employee in Employees)
				result += employee.GetTotalSalaryAtDate(date);
			return result;
		}

	}
}
