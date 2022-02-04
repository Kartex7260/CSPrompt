
namespace CSPrompt.Patterns.Behavioral;

public class Memento
{
	public string State { get; set; }
	public Memento(string state) => State = state;
}

public class Caretaker
{
	public Memento Memento { get; set; }
	public Caretaker(Memento memento) => Memento = memento;
}

public class Originator
{
	private string state = "";
	public Memento Memento
	{
		get => new(state);
		set => state = value.State;
	}
}
