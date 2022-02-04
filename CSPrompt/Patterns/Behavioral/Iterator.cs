
namespace CSPrompt.Patterns.Behavioral;

public class Aggregate<T> : IAggregate<T>
{
	private readonly List<T> _items = new();

	public IIterator<T> CreateIterator() => new Iterator<T>(this);
	public int Count => _items.Count;
	public T this[Index index]
	{
		get => _items[index];
		set => _items[index] = value;
	}
}

public class Iterator<T> : IIterator<T>
{
	private readonly IAggregate<T> aggregate;
	private int current = 0;

	public Iterator(IAggregate<T> aggregate)
	{
		this.aggregate = aggregate;
	}

	public T? First 
	{
		get
		{
			if (aggregate.Count == 0)
				return default;
			return aggregate[0];
		}
	}
	public T? Next 
	{
		get
		{
			T? ret = default;
			if (current < aggregate.Count)
				ret = aggregate[current++];
			return ret;
		}
	}
	public T? CurrentItem 
	{
		get
		{
			if (current >= aggregate.Count || current < 0)
				return default;
			return aggregate[current];
		}
	}
	public bool IsDone => current >= aggregate.Count;
}


public interface IAggregate<T>
{
	IIterator<T> CreateIterator();
	int Count { get; }
	T this[Index index] { get; set; }
}

public interface IIterator<T>
{
	bool IsDone { get; }
	T? First { get; }
	T? Next { get; }
	T? CurrentItem { get; }
}
