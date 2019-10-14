using Adventure.Models;

namespace Adventure.Interfaces
{
	public interface IGame
	{
		IRoom CurrentRoom { get; set; }
		IPlayer CurrentPlayer { get; set; }
		public bool Death { get; set; }
		public bool Victory { get; set; }


		void Setup(string mode);
	}
}