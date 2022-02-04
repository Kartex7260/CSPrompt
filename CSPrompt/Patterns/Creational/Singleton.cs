
namespace CSPrompt.Patterns.Creational;

public class Singleton
{
	public string Name { get; } = "";

	public static Singleton Instance => Lazy.Instance;

	private class Lazy
	{
		public static Singleton Instance = new();
	}
}
