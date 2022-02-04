
namespace CSPrompt.Patterns.Creational;

public class Prototype
{
	public string Name { get; set; } = "";

	public Prototype Clone()
	{
		return new()
		{
			Name = Name
		};
	}
}
