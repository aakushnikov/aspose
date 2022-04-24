using System.Collections;

namespace Aspose.Model.Employees
{
	public interface IStaff : IEnumerable<IEmployee>, IEnumerator
	{
		public void Add(IEmployee employee, IEmployee? supervisor);
		public void Remove(IEmployee employee);
		public void Remove(int id);
		public int Find(IEmployee employee);
		public int Find(int id);
	}
}
