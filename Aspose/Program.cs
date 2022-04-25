/*
using Aspose.Model.Employees;
using System.Diagnostics;

var salesSalary = new Salary("sales", 100, 1, 35, 0.3m, StaffBonusType.AllLevels, true);
var managerSalary = new Salary("manager", 100, 5, 40, 0.5m, StaffBonusType.Level1, true);
var employeeSalary = new Salary("employee", 100, 3, 30, 0, StaffBonusType.None, false);

var hiringDate = DateTime.UtcNow.AddYears(-5);

var e33 = new Employee(33, "level3", hiringDate, employeeSalary);
var e32 = new Employee(32, "level3", hiringDate, salesSalary);
var e31 = new Employee(31, "level3", hiringDate, managerSalary);

var e23 = new Employee(23, "level2", hiringDate, employeeSalary);
var e22 = new Employee(22, "level2", hiringDate, salesSalary);
var e21 = new Employee(21, "level2", hiringDate, managerSalary);

var e13 = new Employee(13, "level1", hiringDate, employeeSalary);
var e12 = new Employee(12, "level1", hiringDate, salesSalary);
var e11 = new Employee(11, "level1", hiringDate, managerSalary);

e33.SetSupervisor(e21);
e32.SetSupervisor(e21);
e31.SetSupervisor(e22);
e23.SetSupervisor(e11);
e22.SetSupervisor(e11);
e21.SetSupervisor(e12);

var queue = new Queue<IEmployee>();
var list = new List<IEmployee>();
var employee = e11;
employee.GetTotalStaff(list, employee);
var data = list.Where(e => e.Staff.Count() == 0).ToList();
employee.FillQueue(data, queue);

while (queue.Count > 0)
{
	var e = queue.Dequeue();
	Debug.WriteLine($"{e.Name}:{e.Id}");
}
*/

Environment.Exit(0);
