using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class SceneBridge : MonoBehaviour {
    [SerializeField] private float fadeOutDuration = 0.2f;
    [SerializeField] private string nextSceneName = default;
    [SerializeField] private Vector2 nextScenePosition = default;

    private void OnTriggerEnter2D(Collider2D other) {
        var player = other.GetComponent<Player>();
        if (player != null) {
            player.frozen = true;
            SceneTransit.SetNextSceneOrientation(nextScenePosition, player.facingDirection);
            StartCoroutine(SceneTransit.LoadSceneAsyncCo(nextSceneName, fadeOutDuration));
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
