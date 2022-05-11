using UnityEngine;

// Boundary idea https://generalistprogrammer.com/unity/unity-2d-how-to-make-camera-follow-player/

[RequireComponent(typeof(BoxCollider2D))]
public class CameraBounds : MonoBehaviour // Raise collider2D for bounding the scene so that camera can capture its target within the collider
{
    [SerializeField] private BoxCollider2D boxCollider;

    private void Awake() => boxCollider = GetComponent<BoxCollider2D>(); // To fetch BoxCollider2D component 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.isTrigger && other.CompareTag("Player"))
        {
            CameraMovement.RaiseCameraBoundsChange(boxCollider.bounds); 

        }
    }
}

