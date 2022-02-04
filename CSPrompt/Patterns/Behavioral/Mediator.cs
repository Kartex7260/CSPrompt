
namespace CSPrompt.Patterns.Behavioral;

public interface IMediator
{
	void Send(string msg, Collegue collegue);
}

public class Mediator : IMediator
{
	private readonly Collegue collegue1;
	private readonly Collegue collegue2;
	public void Send(string msg, Collegue collegue)
	{
		if (collegue == collegue1)
			collegue2.Notify(msg);
		else
			collegue1.Notify(msg);
	}
}

public abstract class Collegue
{
	protected IMediator mediator;
	public Collegue(IMediator mediator) => this.mediator = mediator;
	public void Send(string msg) => mediator.Send(msg, this);
	public abstract void Notify(string msg);
}

public class Collegue1 : Collegue
{
	public Collegue1(IMediator mediator) : base(mediator) { }
	public override void Notify(string msg) { }
}

public class Collegue2 : Collegue
{
	public Collegue2(IMediator mediator) : base(mediator) { }
	public override void Notify(string msg) { }
}
