using UnityEngine;
using UnityEngine.UI;

public class ChoiceDialogNPC : MonoBehaviour
{
    [SerializeField] private TextAsset dialogValue;
    private bool playerInRange; 
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            ChoiceDialogController.RequestChoiceDialog(dialogValue);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.isTrigger && other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.isTrigger && other.CompareTag("Player"))
        {
            playerInRange = false;
            ChoiceDialogController.RequestChoiceDialog(null);
        }
    }
}
