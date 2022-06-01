using System.Collections.Generic; 
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Inventory")]
public class Inventory : ScriptableObject
{
    public List<BookData> books;

    public void Add(BookData book)
    {
        if (!books.Contains(book))
        {
            books.Add(book);
        }
    }

    public void Remove(BookData book)
    {
        books.Remove(book);
    }

    public bool Contains(BookData book)
    {
        return books.Contains(book);
    }

}