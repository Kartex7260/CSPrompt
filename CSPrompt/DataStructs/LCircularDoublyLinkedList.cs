
using System.Collections;

namespace AASDLearning;

public class LCircularDoublyLinkedList<T> : IEnumerable<T>
{

	private LDoublyNode<T>? first;
	private int count = 0;

	public int Count => count;

	public bool IsEmpty => count == 0;

	public void Add(T data)
	{
		LDoublyNode<T> cur = new(data);
		if (IsEmpty)
		{
			first = cur;
			first.Next = cur;
			first.Previous = cur;
		}
		else
		{
			first.Previous.Next = cur;
			cur.Previous = first.Previous;

			first.Previous = cur;
			cur.Next = first;
		}
		count++;
	}

	public void AppendFirst(T data)
	{
		LDoublyNode<T> cur = new(data);
		if (IsEmpty)
		{
			first = cur;
			first.Next = cur;
			first.Previous = cur;
		}
		else
		{
			first.Previous.Next = cur;
			cur.Previous = first.Previous;
			cur.Next = first;
			first.Previous = cur;
			first = cur;
		}
		
		count++;
	}

	public bool Remove(T data)
	{
		if (IsEmpty)
			return false;
		LDoublyNode<T> cur = first;
		do
		{
			if (cur.Data.Equals(data))
			{
				if (count == 1)
				{
					first = null;
					count--;
					return true;
				}
				cur.Previous.Next = cur.Next;
				cur.Next.Previous = cur.Previous;
				if (cur == first)
					first = cur.Next;
				count--;
				return true;
			}
			cur = cur.Next;
		} while (cur != first);
		return false;
	}

	public void Clear()
	{
		first = null;
		count = 0;
	}

	public bool Contains(T data)
	{
		if (IsEmpty)
			return false;
		LDoublyNode<T>? current = first;
		do
		{
			if (current.Data.Equals(data))
				return true;
			current = current.Next;
		} while (current != first);
		return false;
	}

	public void Expand()
	{
		if (IsEmpty)
			return;
		LDoublyNode<T>? cur = first;
		LDoublyNode<T>? next;
		LDoublyNode<T>? previus = first.Previous;
		do
		{
			next = cur.Next;
			cur.Next = cur.Previous;
			cur.Previous = next;
			cur = next;
		} while (cur != first);
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
		do
		{
			yield return current.Data;
			current = current.Next;
		} while (current != first);
	}

	public IEnumerable<T> BackEnumerator()
	{
		LDoublyNode<T> current = first.Previous;
		do
		{
			yield return current.Data;
			current = current.Previous;
		} while (current != first.Previous);
	}

	private LDoublyNode<T> GetDoublyNode(T data)
	{
		LDoublyNode<T>? cur = first;
		do
		{
			if (cur.Data.Equals(data))
				return cur;
			cur = cur.Next;
		} while (cur != first);
		throw new Exception($"Not found {data}");
	}

}