using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPScounter : MonoBehaviour
{
    public int frameRange = 15;
    public TextMeshProUGUI fpsText;

    public List<float> fpsBuffer;
    public int bufferIndex;

    

    void Awake()
    {
        fpsText = GetComponent<TextMeshProUGUI>();
        InitializeBuffer();
    }

    void Update()
    {
        UpdateBuffer();
        UpdateText();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            QualitySettings.SetQualityLevel(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            QualitySettings.SetQualityLevel(1);
        }
    }
    void InitializeBuffer()
    {
        if (frameRange <= 0)
        {
            frameRange = 1;
        }
        fpsBuffer = new List<float>(frameRange);
        for (int i = 0; i < frameRange; i++)
        {
            fpsBuffer.Add(0f); // Initialize with 0s
        }
        bufferIndex = 0;
    }
    void UpdateBuffer()
    {
        bufferIndex++;
        if (bufferIndex >= frameRange)
        {
            bufferIndex = 0;
        }
        fpsBuffer[bufferIndex] = 1f / Time.deltaTime;
        
    }

    void UpdateText()
    {
        float averageFPS = GetAverageFPS();
        if (fpsText != null)
        {
            fpsText.text = "Average FPS: " + averageFPS.ToString("0");
        }
    }

    float GetAverageFPS()
    {
        float sum = 0;
        for (int i = 0; i < frameRange; i++)
        {
            sum += fpsBuffer[i];
        }
        return sum / frameRange;
    }


}
