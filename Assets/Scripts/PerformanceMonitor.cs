using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;

public class PerformanceMonitor : MonoBehaviour
{

    private float fps;
    private float memoryUsage;

    public TextMeshProUGUI fpsLabel;
    public TextMeshProUGUI memoryLabel;

    private bool canRun = false;

    void Update()
    {
        if (canRun)
        {
            fps = 1.0f / Time.deltaTime;
            memoryUsage = UnityEngine.Profiling.Profiler.GetTotalAllocatedMemoryLong() / (1024f * 1024f); //MB
            SetLabels();
        }

    }

    private void OnEnable()
    {
        canRun = true;
    }
    private void OnDisable()
    {
        canRun = false;
    }

    void SetLabels()
    {
        fpsLabel.text = "FPS: " + Mathf.Round(fps);
        memoryLabel.text = "Memory usage: " + Mathf.Round(memoryUsage) + "MB";
    }
}
