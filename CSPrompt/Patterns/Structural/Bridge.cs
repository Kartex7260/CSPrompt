
namespace CSPrompt.Patterns.Structural;

public class Abstraction
{
	public IImplementor Implementor { get; set; }
	public Abstraction(IImplementor implementor) => Implementor = implementor;
	public virtual void Operation() => Implementor.OperationIml();
}

public interface IImplementor
{
	void OperationIml();
}
