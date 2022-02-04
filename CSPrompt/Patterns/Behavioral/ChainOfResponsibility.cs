
namespace CSPrompt.Patterns.Behavioral;

public abstract class IHandler
{
	public IHandler? Successor { get; set; }
	public abstract void HandleRequest(int condition);
}

public class Handler1 : IHandler
{
	public override void HandleRequest(int condition)
	{
		if (condition == 1)
			return;

		if (Successor != null)
			Successor.HandleRequest(condition);
	}
}

public class Handler2 : IHandler
{
	public override void HandleRequest(int condition)
	{
		if (condition == 2)
			return;

		if (Successor != null)
			Successor.HandleRequest(condition);
	}
}
