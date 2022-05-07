using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected PlayerControl player;
    [SerializeField] private ItemData itemData;
    [SerializeField] private bool pickUp = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && player != null)
        {
            PickUp();
        }
        
    }

    private void PickUp()
    {
        if (pickUp) PlayerControl.inventory.Add(this);
    }
}