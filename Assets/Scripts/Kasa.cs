using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Kasa : MonoBehaviour
{
    public float interactionRange = 3f;
    public KeyCode interactionKey = KeyCode.E;
    public TextMeshProUGUI interactionText;
    private GameObject interactableObject;
    private bool isInRange = false;
    private bool canInteract = true;
    private bool isInteracting = false;
    private float nextInteractionTime = 0f;

    private void Start()
    {
        interactionText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(interactionKey) && canInteract && interactableObject.activeSelf && !isInteracting)
        {
            Interact();
        }

        UpdateInteractionText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkout"))
        {
            interactableObject = other.gameObject;
            isInRange = true;
            interactionText.text = "Kliknij E, aby skasowaæ produkty";
            interactionText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == interactableObject)
        {
            interactableObject = null;
            isInRange = false;
            interactionText.gameObject.SetActive(false);
            CancelInvoke("EnableObject");
        }
    }

    private void Interact()
    {
        Debug.Log("Zainteraktowano z obiektem, skasowano produkty");
        isInteracting = true;
        nextInteractionTime = Time.time + 5f;
        Invoke("EnableObject", 5f);
    }

    private void EnableObject()
    {
        isInteracting = false;
        interactionText.gameObject.SetActive(true);
    }

    private void UpdateInteractionText()
    {
        if (isInteracting)
        {
            float timeRemaining = nextInteractionTime - Time.time;
            string timeText = string.Format("<color=white>Czas do kolejnego kasowania:</color> <color=red>{0:0} </color>s", timeRemaining);

            if (timeRemaining <= 0f)
            {
                timeText = "<color=white>Kasowanie dostêpne</color>";
            }

            interactionText.text = "Kliknij E, aby skasowaæ produkty\n" + timeText;
        }
        else
        {
            interactionText.text = "Kliknij E, aby skasowaæ produkty";
        }
    }

}
