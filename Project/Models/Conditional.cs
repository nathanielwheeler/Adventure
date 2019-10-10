using System.Collections.Generic;
using Adventure.Project.Interfaces;

namespace Adventure.Project.Models
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