using System.Collections.Generic;

namespace Adventure.Interfaces
{
	public interface IConditional
	{
		public string Name { get; set; }
		public Dictionary<string, bool> Bools { get; set; }
	}
}