namespace Adventure.Models
{
	public class RiddleRoom : Room
	{
		private int tries;

		public void Riddle()
		{
			while (tries < 3)
			{
				//TODO Build this out
			}
			//you die
		}

		public RiddleRoom(string name, string description, bool death, bool victory) : base(name, description, death, victory)
		{
		}
	}
}