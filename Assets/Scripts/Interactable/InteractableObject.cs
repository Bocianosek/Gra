using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private string interactionText;

    private UIManager uiManager;
    protected PlayerHands playerHands;

    protected bool playerInTrigger;

    protected virtual void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        playerHands = FindObjectOfType<PlayerHands>();
    }

    protected virtual void Update()
    {
        if (playerInTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Gracz nacisn¹³ E!");
                InteractWithObject();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiManager.DisplayInteractionText(interactionText);
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopInteractWithObject();
            playerInTrigger = false;
        }
    }

    protected virtual void InteractWithObject()
    {

    }

    protected virtual void StopInteractWithObject()
    {
        uiManager.ResetInteractionText();
    }
}