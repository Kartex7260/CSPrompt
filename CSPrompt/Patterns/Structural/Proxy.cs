
namespace CSPrompt.Patterns.Behavioral;

public interface ISubject
{
	void Request();
}

public class Subject : ISubject
{
	public void Request() { }
}

public class Proxy : ISubject
{
	private Subject subject = new();
	public void Request() => subject.Request();
}
