using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowFps : MonoBehaviour
{
   
    public TextMeshProUGUI fpsText;
    private float deltaTime = 0.0f;

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        int fps = (int)(1.0f / deltaTime);
        fpsText.text = string.Format("FPS: {0}", fps);
    }
}
