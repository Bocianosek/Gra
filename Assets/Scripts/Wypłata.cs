using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wypłata : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    private float currentValue;
    private float incrementValue = 22.8f;
    private float updateInterval = 60f;
    private float timer = 0f;

    private void Start()
    {
        
        currentValue = PlayerPrefs.GetFloat("StanKonta", 1000f);
        UpdateTextMeshValue();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        
        if (timer >= updateInterval)
        {
            timer = 0f;
            currentValue += incrementValue;
            UpdateTextMeshValue();
        }
    }

    private void UpdateTextMeshValue()
    {
        
        textMesh.text = "Stan Konta: " + currentValue.ToString("F1");

        
        PlayerPrefs.SetFloat("StanKonta", currentValue);
    }
}
