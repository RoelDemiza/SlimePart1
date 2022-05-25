using System;
using UnityEngine;

public class SceneAnchor : MonoBehaviour
{
    public static event Action<Vector2> OnSceneTransition; 
    private static Vector2? _transitionPosition; 
    public static Vector2 transitionPosition {
        set {
            _transitionPosition = value;
        }
    }

    private void Start()
    {
        if (_transitionPosition.HasValue) { 
            OnSceneTransition?.Invoke(_transitionPosition.Value); 
            _transitionPosition = null; 
        }
    }
}
