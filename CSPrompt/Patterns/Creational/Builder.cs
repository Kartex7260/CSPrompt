
namespace CSPrompt.Patterns.Creational;

public abstract class Builder
{
	public abstract void BuildPartA();
	public abstract void BuildPartB();
	public abstract Product Build();
}

public class Product { }
