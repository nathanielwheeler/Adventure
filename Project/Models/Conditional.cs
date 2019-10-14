using System.Collections.Generic;
using Adventure.Interfaces;

namespace Adventure.Models
{
	public class Conditional : IConditional
	{
		public string Name { get; set; }
		public Dictionary<string, bool> Bools { get; set; }

		public Conditional(string name)
		{
			Name = name;
			Bools = new Dictionary<string, bool>();
		}
	}
}