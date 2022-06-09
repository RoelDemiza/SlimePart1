using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CamTrigger : MonoBehaviour
{
    [SerializeField] private new Camera camera;
    private Animator anim;
    private bool playerInRange;

    private void Start()
    {
        anim = camera.GetComponent<Animator>();
    }
    private void Update() 
    {
        if (playerInRange)
        {
            anim.SetBool("isShaking", true);
        }
        else
        {
            anim.SetBool("isShaking", false);
        }
    }
        
    private void OnTriggerEnter2D(Collider2D other) 
    {
        playerInRange = true;
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        playerInRange = false;
    }
}
