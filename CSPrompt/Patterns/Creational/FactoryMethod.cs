
namespace CSPrompt.Patterns.Creational;

public class ToyotaFactory : ICreator
{
	public ICar FabricMethod() => new Toyota("Camry");
}

public class BmwFactory : ICreator
{
	public ICar FabricMethod() => new Bmw("M5");
}

public record class Toyota(string Model) : ICar;
public record class Bmw(string Model) : ICar;

public interface ICreator
{
	ICar FabricMethod();
}

public interface ICar
{
	string Model { get; }
}
