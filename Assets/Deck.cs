using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> Items = new List<Card>();
    public System.Random rnd = new System.Random();
    public void Add(Card thing)
    {
        if (!Items.Contains(thing))
            Items.Add(thing);
    }
    public void Clear()
    {
        Items.Clear();
    }
    public void Remove(Card thing)
    {
        if (Items.Contains(thing))
            Items.Remove(thing);
    }
    public void RemoveLast()
    {
        Items.Remove(Items[Count() - 1]);
    }
    public Card GetLast()
    {
        return Items[Count() - 1];
    }
    public int Count()
    {
        return Items.Count;
    }
    public void Shuffle()
    {
        int n = Items.Count;
        while (n > 1)
        {
            n--;
            int k = rnd.Next(n + 1);
            Card value = Items[k];
            Items[k] = Items[n];
            Items[n] = value;
        }
    }
}
