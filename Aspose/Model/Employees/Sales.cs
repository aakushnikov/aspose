namespace Aspose.Model.Employees
{
	public sealed class Sales : EmployeeBase
	{
		const decimal premium = 0.3M;
		protected override decimal BonusRate { get => 1; }
		protected override decimal BonusLimit { get => 35; }

		public override decimal GetTotalSalaryAtDate(DateTime date)
		{
			var total = base.GetTotalSalaryAtDate(date);
			total += GetTotalStaffSalaryAtDate(date, Staff);
			return total;
		}

		private decimal GetTotalStaffSalaryAtDate(DateTime date, List<IEmployee> list)
		{
			if (list == null) return 0;
			if (list.Count == 0) return 0;
			decimal total = 0;
			foreach (IEmployee employee in list)
			{
				total += employee.GetTotalSalaryAtDate(date) * premium;
				total += GetTotalStaffSalaryAtDate(date, employee.Staff);
			}
			return Math.Round(total, 2);
		}
	}
}
