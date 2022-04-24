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
		[Test]
		public void Test100Employees()
		{
			Company company = new Company();
			List<IEmployee> employees = new List<IEmployee>();

			var salesSalary = new Salary("Sales", 1000, 1, 35, 0.3m, StaffBonusType.AllLevels, true);

			for (int i = 0; i < 100; i++)
			{
				var employee = new Employee(i, "Sales " + i, new DateTime(1970, 1, 1), salesSalary);
				if (i != 0)
				{
					employee.Staff.Add(employees[i - 1], employee);
				}
				employees.Add(employee);
			}

			company.Employees = employees;

			Console.WriteLine("Total: " + company.GetTotalSalaryAtDate(new DateTime(2020, 1, 1)));
		}
	}
}