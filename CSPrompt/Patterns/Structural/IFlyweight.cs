
using System.Collections;

namespace CSPrompt.Patterns.Structural;

public class FlyweightFactory
{
	private readonly Dictionary<string, IFlyweight> flyweights = new();
	public FlyweightFactory() { }
	public IFlyweight GetFlyweight(string key) 
	{
		if (!flyweights.ContainsKey(key))
			flyweights.Add(key, new ConcreteFlyweight());
		return flyweights[key];
	}
}

public interface IFlyweight
{
	void Operation(int extrinsicState);
}

public class ConcreteFlyweight : IFlyweight
{
	int intrinsicState;
	public void Operation(int extrinsicState) { }
}

class UnsharedConcreteFlyweight : IFlyweight
{
	int allState;
	public void Operation(int extrinsicState) => allState = extrinsicState;
}
