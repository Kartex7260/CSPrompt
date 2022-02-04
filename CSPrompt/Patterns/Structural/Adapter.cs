
namespace CSPrompt.Patterns.Structural;

public class Client
{
	public void Reuest(Target target) => target.Request();
}

public class Target
{
	public virtual void Request() { }
}

public class Adapter : Target
{
	Adaptee adaptee = new();

	public override void Request() => adaptee.SpecificRequest();
}

public class Adaptee
{
	public void SpecificRequest() { }
}
