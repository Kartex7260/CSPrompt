
namespace CSPrompt.Patterns.Behavioral;

public interface IState
{
	void Handle(Contex contex);
}

public class Contex
{
	public IState State { get; set; }

	public Contex(IState state) => State = state;
	public void Request() => State.Handle(this);
}
