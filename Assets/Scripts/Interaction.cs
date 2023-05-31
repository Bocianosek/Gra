using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Interaction : MonoBehaviour
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
        if (other.CompareTag("Interactable"))
        {
            interactableObject = other.gameObject;
            isInRange = true;
            interactionText.text = "Kliknij E, aby roz³adowaæ dostawê";
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
        
        Debug.Log("Zainteraktowano z obiektem, roz³adowano dostawê");


        interactableObject.SetActive(false);


        Invoke("EnableObject", 10f);
        interactionText.gameObject.SetActive(false);
    }

    private void EnableObject()
    {
        
        interactableObject.SetActive(true);
    }
}
