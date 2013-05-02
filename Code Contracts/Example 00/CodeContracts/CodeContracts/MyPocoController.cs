using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeContracts
{
	public class MyPocoController
	{
		public MyPocoController()
		{
			_dictionary = new Dictionary<Guid, MyPoco>();
		}


		public MyPoco CreatePoco(Guid id, string name)
		{
			if (name == null)
				throw new ArgumentNullException("name");

			if (_dictionary.ContainsKey(id))
				throw new InvalidOperationException("Duplicate value for id not allowed.");

			var result = new MyPoco() { Id = id, Name = name };
			_dictionary.Add(id, result);
			return result;
		}

		public MyPoco GetPoco(Guid id)
		{
			if (_dictionary.ContainsKey(id) == false)
				return null;

			return _dictionary[id];
		}

		public IEnumerable<MyPoco> GetAllPocos()
		{
			return _dictionary.Values;
		}

		public IEnumerable<MyPoco> FindPocoByName(string name)
		{
			return _dictionary.Values.Where(p => p.Name == name);
		}

		public void UpdatePoco(MyPoco poco)
		{
			if (_dictionary.ContainsKey(poco.Id))
				_dictionary[poco.Id] = poco;
			else
				_dictionary.Add(poco.Id, poco);
		}

		public void RemovePoco(Guid id)
		{
			_dictionary.Remove(id);
		}

		private readonly Dictionary<Guid, MyPoco> _dictionary;
	}
}
