
namespace CSPrompt.Patterns.Behavioral;

public class Context
{
	private readonly Dictionary<string, int> variables = new();

	public int GetVariable(string name) => variables[name];
	public void SetVariable(string name, int value) => variables[name] = value;
}

public interface IExpression
{
	int Interpreter(Context context);
}

public class NumberExpression : IExpression
{
	private readonly string name;
	public NumberExpression(string name) => this.name = name;
	public int Interpreter(Context context) => context.GetVariable(name);
}

public class AddExpression : IExpression
{
	protected readonly IExpression left;
	protected readonly IExpression right;
	public AddExpression(IExpression left, IExpression right) 
	{
		this.left = left;
		this.right = right;
	}
	public virtual int Interpreter(Context context) 
	{
		return left.Interpreter(context) + right.Interpreter(context);
	}
}

public class SubstractExpression : AddExpression
{
	public SubstractExpression(IExpression left, IExpression right) : base(left, right) { }
	public override int Interpreter(Context context)
	{
		return left.Interpreter(context) - right.Interpreter(context);
	}
}

