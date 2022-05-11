using System;
using UnityEngine;

[RequireComponent(typeof(Camera))] 
public class CameraMovement : MonoBehaviour
{
    public static void RaiseCameraBoundsChange(Bounds bounds) => OnCameraBoundsChange?.Invoke(bounds);
    private static event Action<Bounds> OnCameraBoundsChange;

    [SerializeField] private Transform target = default;
    [SerializeField] private float smoothing = 5;

    private Vector2 minPosition;
    private Vector2 maxPosition;

    private new Camera camera;

    private void Awake() => OnCameraBoundsChange += UpdateBounds;
    private void OnDestroy() => OnCameraBoundsChange -= UpdateBounds;

    private void LateUpdate()// Use LateUpdate because only update camera movement after getting min and max position
    {
        if (transform.position != target.position) // If GameObject(MainCamera) position not equal to player position
        { 
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z); // Get Playerposition

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x); // Use Clamp to keep value between minPos and maxPos
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y); // Both min and max position are calculated in camera boundary

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing); // Lerp function used to move camera smoothly while following player 
        }
    }

    private void UpdateBounds(Bounds bounds) // Declare method to read camera boundary
    {
        if (camera == null) camera = GetComponent<Camera>(); // To fetch camera component 

        var halfSize = new Vector2(camera.orthographicSize * camera.aspect, camera.orthographicSize); 
        minPosition = (Vector2)bounds.min + halfSize; // Calculate allowed minimum value 
        maxPosition = (Vector2)bounds.max - halfSize; // Calculate allowed maximum value 
    }
}