using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLogic : MonoBehaviour
{
    
    void Start()
    {
        
    }

    public void OnCloseClicked()
    {
        gameObject.SetActive(false);
        
    }
}
