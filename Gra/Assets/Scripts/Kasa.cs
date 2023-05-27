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

    private void Start()
    {
        interactionText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(interactionKey) && canInteract && interactableObject.activeSelf)
        {
            Interact();
        }
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
        }
    }

    private void Interact()
    {

        Debug.Log("Zainteraktowano z obiektem, skasowano produkty");


        


        Invoke("EnableObject", 5f);
        interactionText.gameObject.SetActive(false);
    }

    private void EnableObject()
    {
        interactionText.gameObject.SetActive(true);

    }
}


