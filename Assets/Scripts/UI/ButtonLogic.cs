using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ParentGO;
    
    void Start()
    {
        
    }

    public void OnCloseClicked()
    {
        ToggleGameObject(ParentGO);
    }
    void ToggleGameObject(GameObject gameObject)
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
