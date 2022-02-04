
namespace CSPrompt.Patterns.Behavioral;

public abstract class Doable
{
	public void Do()
	{
		DoIt();
		Chill();
	}
	public abstract void DoIt();
	public abstract void Chill();
}

public class DoNothing : Doable
{
	public override void Chill() => Console.WriteLine("Chill!");
	public override void DoIt() => Chill();
}

public class DoAlways : Doable
{
	public override void Chill() => Console.WriteLine("Work");
	public override void DoIt() => Console.WriteLine("Work");
}
