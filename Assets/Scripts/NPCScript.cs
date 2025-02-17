using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour, IInteractable
{
    public bool IsSpeaking { get; private set; }

    [SerializeField] private GameObject dialogue;

    // Start is called before the first frame update
    void Start()
    {
        IsSpeaking = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CanInteract()
    {
        return true;
    }

    public void Interact()
    {
        if (!IsSpeaking)
        {
            Speak();
        }
        else
        {
            StopSpeaking();
        }

    }

    private void Speak()
    {
        IsSpeaking = true;
        dialogue.SetActive(true);
    }

    public void StopSpeaking()
    {
        IsSpeaking=false;
        dialogue.SetActive(false);
    }

    
}
