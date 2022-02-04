
namespace CSPrompt.Patterns.Behavioral;

public class Publisher : IObservable
{
	private readonly List<IObserver> subscribers = new();

	public void Add(IObserver obs)
	{
		if (subscribers.Contains(obs))
			return;
		subscribers.Add(obs);
	}

	public void Notify()
	{
		foreach (IObserver obs in subscribers)
			obs.Update();
	}

	public void Remove(IObserver obs) => subscribers.Remove(obs);
}

public interface IObservable
{
	void Add(IObserver obs);
	void Remove(IObserver obs);
	void Notify();
}

public interface IObserver
{
	void Update();
}
