
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class RuntimeSet<T> : ScriptableObject
{
    public List<T> Items = new List<T>();
    public System.Random rnd = new System.Random();
    public void Add(T thing)
    {
        if (!Items.Contains(thing))
            Items.Add(thing);
    }

    public void Remove(T thing)
    {
        if (Items.Contains(thing))
            Items.Remove(thing);
    }
    public void RemoveLast()
    {
        Items.Remove(Items[Count() - 1]);
    }
    public T GetLast()
    {
        return Items[Count() - 1];
    }
    public int Count()
    {
        return Items.Count;
    }
    public void Sort()
    {
        Items.Sort();
    }
    public void Clear()
    {
        Items.Clear();
    }
    public void Shuffle()
    {
        int n = Items.Count;
        while (n > 1)
        {
            n--;
            int k = rnd.Next(n + 1);
            T value = Items[k];
            Items[k] = Items[n];
            Items[n] = value;
        }
    }
} 
