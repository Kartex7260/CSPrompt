
using System.Collections;

namespace AASDLearning;

public class LDoublyLinkedList<T> : IEnumerable<T>
{

	private LDoublyNode<T>? first;
	private LDoublyNode<T>? last;
	private int count = 0;

	public int Count => count;

	public bool IsEmpty => count == 0;

	public void Add(T data)
	{
		LDoublyNode<T> cur = new(data);
		if (first == null)
			first = cur;
		else
		{
			last.Next = cur;
			cur.Previous = last;
		}
		last = cur;
		count++;
	}

	public void AppendFirst(T data)
	{
		LDoublyNode<T> cur = new(data);
		if (first != null)
			first.Previous = cur;
		else
			last = cur;
		cur.Next = first;
		first = cur;
		count++;
	}

	public bool Remove(T data)
	{
		LDoublyNode<T> current = first;

		while (current != null)
		{
			if (current.Data.Equals(data))
				break;
			current = current.Next;
		}
		if (current != null)
		{
			if (current.Next != null)
				current.Next.Previous = current.Previous;
			else
			{
				last = current.Previous;
				last.Next = null;
			}
			if (current.Previous != null)
				current.Previous.Next = current.Next;
			else
			{
				first = current.Next;
				first.Previous = null;
			}
			count--;
			return true;
		}
		return false;
	}

	public void Clear()
	{
		first = null;
		last = null;
		count = 0;
	}

	public bool Contains(T data)
	{
		LDoublyNode<T> current = first;
		while (current != null)
		{
			if (current.Data.Equals(data))
				return true;
			current = current.Next;
		}
		return false;
	}

	public void Expand()
	{
		LDoublyNode<T>? cur = first;
		LDoublyNode<T>? next;
		LDoublyNode<T>? previus = null;
		last = first;
		while (cur != null)
		{
			next = cur.Next;
			cur.Next = cur.Previous;
			cur.Previous = next;
			if (next == null)
				previus = cur;
			cur = next;
		}
		first = previus;
	}

	public void InsertBefore(T elmnt, T data)
	{
		LDoublyNode<T> element = GetDoublyNode(elmnt);
		LDoublyNode<T> cur = new(data);
		element.Previous.Next = cur;
		cur.Previous = element.Previous;
		element.Previous = cur;
		cur.Next = element;
	}

	public void InsertAfter(T elmnt, T data)
	{
		LDoublyNode<T> element = GetDoublyNode(elmnt);
		LDoublyNode<T> cur = new(data);
		element.Next.Previous = cur;
		cur.Next = element.Next;
		element.Next = cur;
		cur.Previous = element;
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

	public IEnumerable<T> BackEnumerator()
	{
		LDoublyNode<T> current = last;
		while (current != null)
		{
			yield return current.Data;
			current = current.Previous;
		}
	}

	private LDoublyNode<T> GetDoublyNode(T data)
	{
		LDoublyNode<T>? cur = first;
		while (cur != null)
		{
			if (cur.Data.Equals(data))
				return cur;
			cur = cur.Next;
		}
		throw new Exception($"Not found {data}");
	}

}

public class LDoublyNode<T>
{

	public T Data { get; }

	public LDoublyNode<T>? Previous;
	public LDoublyNode<T>? Next;

	public LDoublyNode(T data)
	{
		Data = data;
	}

}
