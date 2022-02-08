using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AASDLearning;

public class LNodeStack<T> : IEnumerable<T>
{

	private LNode<T>? first;
	int count = 0;

	public int Count => count;

	public bool IsEmpty => count == 0;

	public void Push(T item)
	{
		LNode<T> cur = new(item);
		cur.Next = first;
		first = cur;
		count++;
	}

	public T Pop()
	{
		if (IsEmpty)
			throw new InvalidOperationException("Stack is empty");
		count--;
		LNode<T> cur = first;
		first = cur.Next;
		return cur.Data;
	}

	public T Peek()
	{
		if (IsEmpty)
			throw new InvalidOperationException("Stack is empty");
		return first.Data;
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
