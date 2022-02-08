using System.Collections;

namespace AASDLearning;

public class LLinkedList<T> : IEnumerable<T>
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
		count++;
	}

	public bool Remove(T data)
	{
		LNode<T>? cur = first;
		LNode<T>? previues = null;
		while (cur != null)
		{
			if (cur.Data.Equals(data))
			{
				if (previues != null)
				{
					previues.Next = cur.Next;
					if (cur.Next == null)
						last = previues;
				}
				else
				{
					first = cur.Next;
					if (first == null)
						last = null;
				}
				count--;
				return true;
			}

			previues = cur;
			cur = cur.Next;
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
		LNode<T> cur = first;
		while (first != null)
		{
			if (cur.Data.Equals(data))
				return true;
			cur = cur.Next;
		}
		return false;
	}

	public void AppendFirst(T data)
	{
		LNode<T> node = new(data);
		node.Next = first;
		first = node;
		if (count == 0)
			last = first;
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
		LNode<T>? previus = null;
		LNode<T>? next;
		last = cur;
		while (cur != null)
		{
			next = cur.Next;
			cur.Next = previus;
			previus = cur;
			cur = next;
		}
		first = previus;
	}

	// реализация интерфейса IEnumerable
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

	private LNode<T> GetNode(T data)
	{
		LNode<T>? cur = first;
		while (cur != null)
		{
			if (cur.Data.Equals(data))
				return cur;
			cur = cur.Next;
		}
		throw new Exception($"Not found {data}");
	}

	private LNode<T> GetPreviusNode(T data)
	{
		LNode<T>? cur = first;
		LNode<T>? pre = null;
		while (cur != null)
		{
			if (cur.Data.Equals(data))
				return pre;
			pre = cur;
			cur = cur.Next;
		}
		throw new Exception($"Not found {data}");
	}

}

public class LNode<T>
{

	public T Data { get; set; }
	public LNode<T>? Next { get; set; }

	public LNode(T data)
	{
		Data = data;
	}

}
