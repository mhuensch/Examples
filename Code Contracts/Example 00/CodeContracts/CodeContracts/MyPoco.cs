using System;
using System.Collections.Generic;

namespace CodeContracts
{
	public class MyPoco
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public IEnumerable<MyPoco> Children { get; set; }
	}
}
