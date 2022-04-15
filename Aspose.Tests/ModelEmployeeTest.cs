using System;
using System.Collections.Generic;
using NUnit.Framework;
using TheoryAttribute = NUnit.Framework.TheoryAttribute;
using Aspose.Model.Employees;

namespace Aspose.Tests
{
	[TestFixture]
	public class ModelEmployeeTest
	{
		[Theory]
		[TestCase(typeof(Sales), 5, 105)]
		[TestCase(typeof(Sales), 55, 135)]
		[TestCase(typeof(Manager), 5, 125)]
		[TestCase(typeof(Manager), 55, 140)]
		[TestCase(typeof(Employee), 3, 109)]
		[TestCase(typeof(Employee), 55, 130)]
		public void IsTotalSalaryAtDateCorrect(Type type, int workingYears, double expectedTotalSalary)
		{
			var employee = (IEmployee)Activator.CreateInstance(type);
			employee.Salary = 100;
			employee.HiringDate = DateTime.UtcNow.AddYears(-workingYears);
			Assert.AreEqual(employee.GetTotalSalaryAtDate(DateTime.UtcNow), expectedTotalSalary);
		}

		[Test]
		public void CanEmployeeHasStaff()
		{
			var employee = new Employee();
			Assert.Catch(typeof(ArgumentException), () => { employee.Staff = new List<IEmployee>(); });
			Assert.Catch(typeof(ArgumentException), () => { employee.Supervisor = new Employee(); });
		}
	}
}