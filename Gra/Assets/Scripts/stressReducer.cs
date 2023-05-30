using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class stressReducer : MonoBehaviour
{
    public float interactionRange = 3f;
    public KeyCode interactionKey = KeyCode.E;
    public TextMeshProUGUI interactionText;
    public StresManager stresManager;

    private GameObject interactableObject;
    private bool isInRange = false;
    private bool canInteract = true;
    private bool canReduceStress = true;
    private float nextInteractionTime = 0f;

    private void Start()
    {
        interactionText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(interactionKey) && canInteract && interactableObject.activeSelf && canReduceStress)
        {
            Interact();
        }

        if (!canReduceStress)
        {
            UpdateInteractionText();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Palenie"))
        {
            interactableObject = other.gameObject;
            isInRange = true;
            interactionText.text = "Kliknij E, aby zapaliæ";
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
        Debug.Log("Zainteraktowano z obiektem, zapalono");
        stresManager.ReduceStressValue(10);
        canReduceStress = false;
        nextInteractionTime = Time.time + 10f;
        StartCoroutine(EnableReduceStress());
    }

    private IEnumerator EnableReduceStress()
    {
        yield return new WaitForSeconds(10f);
        canReduceStress = true;
        interactionText.text = "Kliknij E, aby zapaliæ";
    }

    private void UpdateInteractionText()
    {
        float timeRemaining = nextInteractionTime - Time.time;
        string timeText = string.Format("Mo¿esz zapaliæ ponownie za: <color=red>{0:0}</color> s", timeRemaining);
        interactionText.text = "Kliknij E, aby zapaliæ\n" + timeText;
    }
}
