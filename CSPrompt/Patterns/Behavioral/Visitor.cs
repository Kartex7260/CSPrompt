
namespace CSPrompt.Patterns.Behavioral;

public interface IVisitor
{
	void VisitElementA(ElementA element);
	void VisitElementB(ElementB element);
}

public class ObjectStructure
{
	private readonly List<Element> elements = new();
	public void Add(Element element) => elements.Add(element);
	public void Remove(Element element) => elements.Remove(element);
	public void Accept(IVisitor visitor)
	{
		foreach (Element element in elements)
			element.Accept(visitor);
	}
}

public class VisitorA : IVisitor
{
	public void VisitElementA(ElementA element) => element.OperationA();
	public void VisitElementB(ElementB element) => element.OperationB();
}

public abstract class Element
{
	public string Name { get; set; } = "";
	public abstract void Accept(IVisitor visitor);
}

public class ElementA : Element
{
	public override void Accept(IVisitor visitor) => visitor.VisitElementA(this);
	public void OperationA() { }
}

public class ElementB : Element
{
	public override void Accept(IVisitor visitor) => visitor.VisitElementB(this);
	public void OperationB() { }
}
