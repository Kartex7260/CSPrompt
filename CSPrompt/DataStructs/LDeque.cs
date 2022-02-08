using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AASDLearning;

public class LDeque<T> : IEnumerable<T>
{

	private LDoublyNode<T>? first;
	private LDoublyNode<T>? last;
	private int count = 0;

	public int Count => count;

	public bool IsEmpty => count == 0;

	public T First
	{
		get
		{
			if (first == null)
				throw new InvalidOperationException("Deque is empty");
			return first.Data;
		}
	}

	public T Last
	{
		get
		{
			if (last == null)
				throw new InvalidOperationException("Deque is empty");
			return last.Data;
		}
	}

	public void AddLast(T data)
	{
		LDoublyNode<T> cur = new(data);

		if (first == null)
			first = cur;
		else
		{
			last.Next = cur;
			cur.Previous = cur;
		}

		last = cur;
		count++;
	}

	public void AddFirst(T data)
	{
		LDoublyNode<T> cur = new(data);

		if (count == 0)
			last = cur;
		else
		{
			first.Previous = cur;
			cur.Next = first;
		}

		first = cur;

		count++;
	}

	public T RemoveFirst()
	{
		if (first == null)
			throw new InvalidOperationException("Deque is empty");
		if (count == 1)
			last = null;
		T data = first.Data;
		first = first.Next;
		count--;
		return data;
	}

	public T RemoveLast()
	{
		if (last == null)
			throw new Exception("Deque is empty");

		T data = last.Data;
		last = last.Previous;
		if (last == null)
			first = null;

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
		LDoublyNode<T>? cur = first;
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
		LDoublyNode<T> current = first;
		while (current != null)
		{
			yield return current.Data;
			current = current.Next;
		}
	}

}
