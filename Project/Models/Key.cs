using System.Collections.Generic;
using Adventure.Interfaces;

namespace Adventure.Models
{
	public class Key : IKey
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string TargetDirection { get; set; }
		public IRoom TargetDestination { get; set; }
		public IRoom ValidRoom { get; set; }


		public string GetDescription()
		{
			return Description;
		}



		public Key(string name, string description, string targetDirection, IRoom targetDestination, IRoom validRoom)
		{
			Name = name;
			Description = description;
			TargetDirection = targetDirection;
			TargetDestination = targetDestination;
			ValidRoom = validRoom;
		}
	}
}