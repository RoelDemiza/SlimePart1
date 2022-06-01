using UnityEngine;

public class PickUp : ReadBook
{
    private void OnValidate()
    {
        var sprite = GetComponent<SpriteRenderer>();
        if (sprite != null && book != null)
        {
            sprite.color = book.color;
        }
    }

    [SerializeField] private bool pickUp = true;

    protected override void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && player != null)
        {
            Pickup();
        }
        
    }
    private void Pickup()
    {
        if (pickUp) BookUI.ReadBook(book);
        player.inventory.Add(book);
        gameObject.SetActive(false);
    }
}
