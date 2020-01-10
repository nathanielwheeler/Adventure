namespace Adventure.Project.Interfaces
{
	public interface IItem
	{
		string Name { get; set; }
		string Description { get; set; }
		bool CanGet { get; set; }
	}
}