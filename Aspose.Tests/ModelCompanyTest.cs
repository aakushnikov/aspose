using System;
using System.Collections.Generic;
using NUnit.Framework;
using Aspose.Model.Companies;
using Aspose.Model.Employees;

namespace Aspose.Tests
{
	[TestFixture]
	public class ModelCompanyTest
	{
		List<IEmployee> _employees;
		[SetUp]
		public void Init()
		{
			/* M ( S ( S ) E )		M		S		S
			 *						|\		|		|
			 * S ( M ( M E ))		S E		M		E
			 *						|		|\
			 * S ( E )				S		M E
			 * */
			var level1 = new List<IEmployee>()
			{
				new Manager() { Id = "1", Name = "Manager11", HiringDate = DateTime.UtcNow.AddYears(-5), Salary = 100, Staff = null, Supervisor = null },
				new Sales() { Id = "2", Name = "Sales11", HiringDate = DateTime.UtcNow.AddYears(-5), Salary = 100, Staff = null, Supervisor = null },
				new Sales() { Id = "3", Name = "Sales12", HiringDate = DateTime.UtcNow.AddYears(-5), Salary = 100, Staff = null, Supervisor = null },
			};

			var level2 = new List<IEmployee>()
			{
				new Manager() { Id = "4", Name = "Manager21", HiringDate = DateTime.UtcNow.AddYears(-5), Salary = 100, Staff = null, Supervisor = level1[1] },
				new Sales() { Id = "5", Name = "Sales21", HiringDate = DateTime.UtcNow.AddYears(-5), Salary = 100, Staff = null, Supervisor = level1[0] },
				new Employee() { Id = "6", Name = "Employee21", HiringDate = DateTime.UtcNow.AddYears(-5), Salary = 100, Staff = null, Supervisor = level1[2] },
				new Employee() { Id = "10", Name = "Employee22", HiringDate = DateTime.UtcNow.AddYears(-5), Salary = 100, Staff = null, Supervisor = level1[0] }, 
			};

			var level3 = new List<IEmployee>()
			{
				new Manager() { Id = "7", Name = "Manager31", HiringDate = DateTime.UtcNow.AddYears(-5), Salary = 100, Staff = null, Supervisor = level2[1] },
				new Sales() { Id = "8", Name = "Sales31", HiringDate = DateTime.UtcNow.AddYears(-5), Salary = 100, Staff = null, Supervisor = level2[0] },
				new Employee() { Id = "9", Name = "Employee31", HiringDate = DateTime.UtcNow.AddYears(-5), Salary = 100, Staff = null, Supervisor = level2[1] },
			};

			level1[0].Staff = new List<IEmployee> { level2[1], level2[3] };
			level1[1].Staff = new List<IEmployee> { level2[0] };
			level1[2].Staff = new List<IEmployee> { level2[2] };

			level2[0].Staff = new List<IEmployee> { level3[1] };
			level2[1].Staff = new List<IEmployee> { level3[0], level3[2] };

			_employees = level1;
		}

		[Theory]
		[TestCase(553.5)]
		public void IsTotalSalaryAtDateCorrect(decimal expectedTotalSalary)
		{
			var company = new Company();
			company.Employees = _employees;
			Assert.AreEqual(company.GetTotalSalaryAtDate(DateTime.UtcNow), expectedTotalSalary);
		}
	}
}
