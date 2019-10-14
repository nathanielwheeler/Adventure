using System.Collections.Generic;

namespace Adventure.Interfaces
{
	public interface IKey
	{
		string Name { get; set; }
		string Description { get; set; }
		public string TargetDirection { get; set; }
		public IRoom TargetDestination { get; set; }
		public IRoom ValidRoom { get; set; }

		string GetDescription();


	}
}