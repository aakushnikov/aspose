using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose.Model.Employees
{
	public sealed class Manager : EmployeeBase
	{
		const decimal premium = 0.5M;
		protected override decimal BonusRate { get => 5; }
		protected override decimal BonusLimit { get => 40; }
		public override decimal Salary { get; set; }

		public override decimal GetTotalSalaryAtDate(DateTime date)
		{
			var total = base.GetTotalSalaryAtDate(date);
			if (Staff != null && Staff.Count > 0)
				total += Staff.Sum(x => x.Salary) * premium;
			return Math.Round(total, 2);
		}
	}
}
