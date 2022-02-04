
namespace CSPrompt.Patterns.Structural;

public interface IComponent
{
	void Operation();
}

public class Decorator : IComponent
{
	public IComponent? Component { get; set; }
	public virtual void Operation() => Component?.Operation();
}

public class DecoratorA : Decorator
{
	public override void Operation() => Console.WriteLine("Decorator A");
}

public class DecoratorB : Decorator
{
	public override void Operation() => Console.WriteLine("Decorator B");
}
