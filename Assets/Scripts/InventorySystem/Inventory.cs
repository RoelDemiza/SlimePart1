using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Scriptable Object/Inventory")]
public class Inventory : ScriptableObject
{
    public List<Item> items;

    public void Add(Item item)
    {
        if (!items.Contains(item))
        {
            items.Add(item);
        }
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

    public bool Contains(Item book)
    {
        return items.Contains(book);
    }

}