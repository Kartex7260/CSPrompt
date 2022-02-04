
namespace CSPrompt.Patterns.Behavioral;

public interface ICommand
{
	void Execute();
	void Undo();
}

public class Command : ICommand
{
	private readonly Receiver receiver;
	public Command(Receiver receiver)
	{
		this.receiver = receiver;
	}
	public void Execute() => receiver.Operation();
	public void Undo() { }
}

public class Receiver
{
	public void Operation() { }
}

public class Invoker
{
	private ICommand? command;

	public void SetCommand(ICommand command) => this.command = command;
	public void Execute() => command?.Execute();
	public void Undo() => command?.Undo();
}
