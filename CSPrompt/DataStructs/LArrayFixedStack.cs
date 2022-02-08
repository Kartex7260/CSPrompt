using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AASDLearning;

public class LArrayStack<T>
{

	private T[] items;
	private int count;
	const int DefaultCount = 10;

	public LArrayStack() { items = new T[DefaultCount]; }

	public LArrayStack(int size)
	{
		items = new T[size];
	}

	public bool IsEmpty => count == 0;

	public int Count => count;

	public void Push(T item)
	{
		if (count == items.Length)
			Resize(items.Length + DefaultCount);
		items[count++] = item;
	}

	public T Pop()
	{
		if (IsEmpty)
			throw new InvalidOperationException("Стек пустой");
		T item = items[--count];
		items[count] = default(T);

		if (count > 0 && count < items.Length - DefaultCount)
			Resize(items.Length - DefaultCount);

		return item;
	}

	public T Peek()
	{
		if (IsEmpty)
			throw new InvalidOperationException("Стек пустой");
		return items[count - 1];
	}

	public void Resize(int size)
	{
		T[] buf = new T[size];
		items.CopyTo(buf, 0);
		items = buf;
	}

}

public class LArrayFixedStack<T>
{

	private T[] items;
	private int count;
	const int DefaultCount = 10;

	public LArrayFixedStack() { items = new T[DefaultCount]; }

	public LArrayFixedStack(int size)
	{
		items = new T[size];
	}

	public bool IsEmpty => count == 0;

	public int Count => count;

	public void Push(T item)
	{
		if (count == items.Length)
			throw new InvalidOperationException("Переполнение стека");
		items[count++] = item;
	}

	public T Pop()
	{
		if (IsEmpty)
			throw new InvalidOperationException("Стек пустой");
		T item = items[--count];
		items[count] = default(T);
		return item;
	}

	public T Peek()
	{
		if (IsEmpty)
			throw new InvalidOperationException("Стек пустой");
		return items[count - 1];
	}

}
