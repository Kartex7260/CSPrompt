
namespace CSPrompt.Patterns.Creational;

public class Client
{
	private readonly ICar car;
	public Client(ICreator creator)
	{
		car = creator.FabricMethod();
	}
}
