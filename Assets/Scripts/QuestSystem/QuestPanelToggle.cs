using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPanelToggle : MonoBehaviour
{
    public GameObject questPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PanelToggle()
    {
        questPanel.SetActive(!questPanel.activeSelf);
    }
}
