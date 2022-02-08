using System.Collections;

namespace AASDLearning;

public class LCircularLinkedList<T> : IEnumerable<T>
{

	private LNode<T>? first;
	private LNode<T>? last;
	private int count = 0;

	public int Count => count;

	public bool IsEmpty => count == 0;

	public void Add(T data)
	{
		LNode<T> node = new(data);

		if (first == null)
			first = node;
		else
			last.Next = node;
		last = node;
		last.Next = first;
		count++;
	}

	public bool Remove(T data)
	{
		LNode<T>? cur = first;
		LNode<T>? prev = last;
		do
		{
			if (cur.Data.Equals(data))
			{
				if (count == 1)
				{
					first = null;
					last = null;
				}
				else
				{
					if (cur == first)
						first = cur.Next;

					if (cur == last)
						last = prev;
					prev.Next = cur.Next;
				}
				count--;
				return true;
			}
			prev = cur;
			cur = cur.Next;
		} while (cur != first);

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
		LNode<T>? cur = first;
		if (first == null)
			return false;
		do
		{
			if (cur.Data.Equals(data))
				return true;
			cur = cur.Next;
		} while (cur != first);
		return false;
	}

	public void AppendFirst(T data)
	{
		LNode<T> cur = new(data);
		cur.Next = first;
		first = cur;
		if (count == 0)
			last = first;

		last.Next = first;
		count++;
	}

	public void InsertBefore(T elmnt, T data)
	{
		LNode<T> pre = GetPreviusNode(elmnt);
		LNode<T> cur = new(data);
		cur.Next = pre.Next;
		pre.Next = cur;
	}

	public void InsertAfter(T elmnt, T data)
	{
		LNode<T> pre = GetNode(elmnt);
		LNode<T> cur = new(data);
		cur.Next = pre.Next;
		pre.Next = cur;
	}

	public void Expand()
	{
		LNode<T>? cur = first;
		LNode<T>? previus = last;
		LNode<T>? next;
		LNode<T>? futLast = cur;
		do
		{
			next = cur.Next;
			cur.Next = previus;
			previus = cur;

			cur = next;
		} while (cur != first);
		last = futLast;
		first = previus;
	}

	// реализация интерфейса IEnumerable
	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable) this).GetEnumerator();
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		LNode<T> cur = first;
		do
		{
			yield return cur.Data;
			cur = cur.Next;
		} while (cur != first);
	}

	private LNode<T> GetNode(T data)
	{
		LNode<T>? cur = first;
		do
		{
			if (cur.Data.Equals(data))
				return cur;
			cur = cur.Next;
		} while (cur != first);
		throw new Exception($"Not found {data}");
	}

	private LNode<T> GetPreviusNode(T data)
	{
		LNode<T>? cur = first;
		LNode<T>? pre = last;
		do
		{
			if (cur.Data.Equals(data))
				return pre;
			pre = cur;
			cur = cur.Next;
		} while (cur != first);
		throw new Exception($"Not found {data}");
	}

}
