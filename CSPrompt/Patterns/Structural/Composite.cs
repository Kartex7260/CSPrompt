
namespace CSPrompt.Patterns.Structural;

abstract class Component
{
	protected string name;
	public Component(string name) => this.name = name;

	public abstract void Display();
	public abstract void Add(Component c);
	public abstract void Remove(Component c);
}
class Composite : Component
{
	private readonly List<Component> children = new();

	public Composite(string name) : base(name) { }

	public override void Add(Component component) => children.Add(component);
	public override void Remove(Component component) => children.Remove(component);
	public override void Display()
	{
		Console.WriteLine(name);

		foreach (Component component in children)
		{
			component.Display();
		}
	}
}
class Leaf : Component
{
	public Leaf(string name) : base(name) { }

	public override void Display() => Console.WriteLine(name);

	public override void Add(Component component) => throw new NotImplementedException();

	public override void Remove(Component component) => throw new NotImplementedException();
}
