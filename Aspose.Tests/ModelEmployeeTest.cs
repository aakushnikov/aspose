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
		[TestCase(100, 1, 35, 0.3, StaffBonusType.AllLevels, true, 5, 105)]
		[TestCase(100, 1, 35, 0.3, StaffBonusType.AllLevels, true, 55, 135)]
		[TestCase(100, 5, 40, 0.5, StaffBonusType.Level1, true, 5, 125)]
		[TestCase(100, 5, 40, 0.5, StaffBonusType.Level1, true, 55, 140)]
		[TestCase(100, 3, 30, 0, StaffBonusType.None, false, 3, 109)]
		[TestCase(100, 3, 30, 0, StaffBonusType.None, false, 55, 130)]
		public void IsTotalSalaryAtDateCorrect(decimal baseSalary, decimal yearBonusRate, decimal totalBonusLimit, decimal staffBonusRate,
			StaffBonusType staffBonusType, bool canHasStaff, int workingYears, decimal expectedTotalSalary)
		{
			var hiringDate = DateTime.UtcNow.AddYears(-workingYears);

			var salary = new Salary("", baseSalary, yearBonusRate, totalBonusLimit, staffBonusRate, staffBonusType, canHasStaff);
			var employee = new Employee(1, "", hiringDate, salary);

			Assert.AreEqual(employee.GetTotalSalaryAtDate(DateTime.UtcNow), expectedTotalSalary);
		}

		[Test]
		public void CanEmployeeHasStaff()
		{
			var employeeSalary = new Salary("Employee", 100, 3, 30, 0, StaffBonusType.None, false);
			var salesSalary = new Salary("Sales", 100, 1, 35, 0.3m, StaffBonusType.AllLevels, true);
			var employee = new Employee(1, "", DateTime.Now.AddYears(-1), employeeSalary);
			var sales = new Employee(2, "", DateTime.Now.AddYears(-1), salesSalary);
			Assert.Catch(typeof(ArgumentException), () => { employee.SetStaff(new Staff()); });
			Assert.Catch(typeof(ArgumentException), () => { sales.SetSupervisor(employee); });
			Assert.Catch(typeof(ArgumentException), () => { sales.SetSupervisor(sales); });
			Assert.Catch(typeof(ArgumentNullException), () => { sales.SetStaff(null); });
		}
	}
}