using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionDetectorScript : MonoBehaviour
{
    private IInteractable interactableInRange = null;
    public GameObject interactionIcon;
    // Start is called before the first frame update
    void Start()
    {
        interactionIcon.SetActive(false);
    }

    public void OnInteract()
    {
        //esto viene del player y si se ejecuta interactuamos
        interactableInRange?.Interact();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable) && interactable.CanInteract())
        {
            interactableInRange = interactable;
            interactionIcon.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable) && interactable == interactableInRange)
        {
            interactableInRange = null;
            interactionIcon.SetActive(false);
        }

        //si se sale del rango y sigue hablando que se calle
        if (collision.CompareTag("NPC"))
        {
            NPCScript npc = collision.gameObject.GetComponent<NPCScript>();
            if (npc.IsSpeaking)
            {
                npc.StopSpeaking();
            }
        }
    }
}
