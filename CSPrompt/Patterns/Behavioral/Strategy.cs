
namespace CSPrompt.Patterns.Behavioral;

public interface IStrategy
{
	void Algorithm();
}

public class Strategy1 : IStrategy
{
	public void Algorithm() => Console.WriteLine("Strategy 1");
}

public class Strategy2 : IStrategy
{
	public void Algorithm() => Console.WriteLine("Strategy 2");
}

public class PentagonHack
{
	private readonly IStrategy strategy;
	public PentagonHack(IStrategy strategy)
	{
		this.strategy = strategy;
	}
	public void Hack() => strategy.Algorithm();
}
