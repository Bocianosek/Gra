using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StresManager : MonoBehaviour
{
    public TextMeshProUGUI stressText;
    public GameObject blurPanel;
    private int stressValue = 0;
    private float updateInterval = 30f;
    private float timer = 0f;
    private bool isBlurred = false;

    private void Start()
    {
        UpdateStressText();
        blurPanel.SetActive(false);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        // Sprawdzenie, czy minê³o 30 sekund
        if (timer >= updateInterval)
        {
            timer = 0f;
            IncrementStressValue();
        }

        // Sprawdzenie, czy wartoœæ "Stres" osi¹gnê³a 100
        if (stressValue >= 100 && !isBlurred)
        {
            isBlurred = true;
            BlurScreen();
        }
        if (stressValue < 100 && !isBlurred)
        {
            isBlurred = false;
            
        }
    }

    private void IncrementStressValue()
    {
        stressValue += 1;
        UpdateStressText();
    }

    private void UpdateStressText()
    {
        stressText.text = "Stres: " + stressValue.ToString();
    }

    private void BlurScreen()
    {
        // Aktywuj efekt blurowania ekranu
        blurPanel.SetActive(true);
    }
}
