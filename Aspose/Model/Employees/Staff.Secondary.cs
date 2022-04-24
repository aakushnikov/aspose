using System.Collections;

namespace Aspose.Model.Employees
{
	public sealed partial class Staff : IStaff
	{
		private int _current;
		public IEnumerator<IEmployee> GetEnumerator()
		{
			return _list.GetEnumerator();
		}

		public bool MoveNext()
		{
			if (_list.Count == 0 || _list.Count <= _current) return false;
			return true;
		}

		public void Reset()
		{
			_current = 0;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public IEmployee this[int index]
		{
			get { return _list[index]; }
			set { _list.Insert(index, value); }
		}

		public object Current => _list.ElementAt(_current);
	}
}
