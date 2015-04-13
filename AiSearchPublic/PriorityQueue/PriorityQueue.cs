using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class PriorityQueue<T> where T : IComparable, MinMaxElement<T>, new()
{

    private List<T> list;

    public PriorityQueue()
    {
        this.list = new List<T>();
        this.list.Add(new T().MaxElement());
    }

    public T DeleteMin()
    {
        if (list.Count < 2)
            throw new InvalidOperationException("Queue is empty");
        T min = list[1];
        list[1] = list[list.Count - 1];
        list.RemoveAt(list.Count-1);
        MinHeapify(1);
        return min;
    }

    public bool IsEmpty()
    {
        return list.Count < 2;
    }

    public void ReplaceWithLower(T oldVal, T newVal)
    {
        int index = list.IndexOf(oldVal);
        DecreaseKey(index, newVal);
    }

    public void Insert(T value)
    {
        InsertMin(value);
    }


    private void MinHeapify(int i)
    {
        int l = 2 * i;
        int r = 2 * i + 1;
        int smallest;
        if (l <= (list.Count-1) && list[l].CompareTo(list[i]) < 0)
            smallest = l;
        else
            smallest = i;
        if (r <= (list.Count-1) && list[r].CompareTo(list[smallest]) < 0)
            smallest = r;
        if (smallest != i)
        {
            T temp = list[i];
            list[i] = list[smallest];
            list[smallest] = temp;
            MinHeapify(smallest);   
        }
    }

    private void InsertMin(T value)
    {
        list.Add(new T().MaxElement());
        DecreaseKey(list.Count-1, value);
    }

    private void DecreaseKey(int i, T value)
    { 
        if(value.CompareTo(list[i]) > 0)
            throw new InvalidOperationException("The key is larger than the current key");
        list[i] = value;
        while (i > 1 && list[i / 2].CompareTo(list[i]) > 0)
        {
            T temp = list[i];
            list[i] = list[i / 2];
            list[i / 2] = temp;
            i = i / 2;
        }
    }

}
