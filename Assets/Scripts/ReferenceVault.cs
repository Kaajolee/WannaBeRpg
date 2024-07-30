using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceVault : MonoBehaviour
{
    public static ReferenceVault Instance { get; set; }
    public Canvas MainCanvas;
    public GameObject ItemBagPanel;
    public GameObject UIItemPrefab;
    public GameObject buttonTextBox;

    private void Start()
    {
        
        Instance = this;
    }
}
