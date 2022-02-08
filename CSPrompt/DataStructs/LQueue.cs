using System.Collections;

namespace AASDLearning;

public class Queue<T> : IEnumerable<T>
{

	private LNode<T>? first;
	private LNode<T>? last;
	private int count = 0;

	public int Count => count;

	public bool IsEmpty => count == 0;

	public T First
	{
		get
		{
			if (IsEmpty)
				throw new InvalidOperationException("Queue is empty");
			return first.Data;
		}
	}

	public T Last
	{
		get
		{
			if (IsEmpty)
				throw new InvalidOperationException("Queue is empty");
			return last.Data;
		}
	}

	public void Enqueue(T data)
	{
		LNode<T> cur = new(data);

		if (first == null)
			first = cur;
		else
			last.Next = cur;

		last = cur;
		count++;
	}

	public T Dequeue()
	{
		if (IsEmpty)
			throw new InvalidOperationException("Queue is empty");
		T data = first.Data;
		first = first.Next;
		count--;
		return data;
	}

	public void Clear()
	{
		first = null;
		last = null;
		count = 0;
	}

	public bool Contains(T data)
	{
		LNode<T> cur = first;
		while (cur != null)
		{
			if (cur.Data.Equals(data))
				return true;
			cur = cur.Next;
		}
		return false;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable) this).GetEnumerator();
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		LNode<T> current = first;
		while (current != null)
		{
			yield return current.Data;
			current = current.Next;
		}
	}

}
