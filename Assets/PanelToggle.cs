using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelToggle : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform questGiverPanel;
    public void TogglePanel()
    {
        questGiverPanel.gameObject.SetActive(!questGiverPanel.gameObject.activeSelf);
    }
}
