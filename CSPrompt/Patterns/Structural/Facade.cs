
namespace CSPrompt.Patterns.Structural;

public class SubA
{
	public void A1() { }
}

public class SubB
{
	public void B1() { }
}

public class SubC
{
	public void C1() { }
}

public class Facade
{
	private readonly SubA subA;
	private readonly SubB subB;
	private readonly SubC subC;
	public Facade(SubA subA, SubB subB, SubC cubC) 
	{
		this.subA = subA;
		this.subB = subB;
		this.subC = cubC;
	}

	public void Operation1() 
	{
		subA.A1();
		subB.B1();
		subC.C1();
	}
	public void Operation2() 
	{
		subA.A1();
		subC.C1();
	}
}
