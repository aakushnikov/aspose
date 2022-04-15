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
			return Employees.Sum(x => x.GetTotalSalaryAtDate(date));
		}

	}
}
