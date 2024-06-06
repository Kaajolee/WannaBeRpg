using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFacingThePlayer : MonoBehaviour
{
    void Update()
    {
        if (gameObject.activeSelf)
            Rotate();
            
    }
    void Rotate()
    {
        transform.LookAt(transform.position + Camera.main.transform.forward);

    }
}
