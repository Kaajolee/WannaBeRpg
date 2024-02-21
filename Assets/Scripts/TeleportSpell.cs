using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TeleportSpell : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxDistance;
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            Teleport();
        }
    }
    Vector3 FindDestination()
    {
        RaycastHit hit;
        Vector3 destination = transform.position;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            Debug.Log("pataike");
            destination = hit.point;
            return destination;
        }
        else
        {
            Debug.Log("Nepataike");
            return destination;
        }
            
        
    }
    void Teleport()
    {
        Vector3 destination = FindDestination();
        transform.position = destination;
        Physics.SyncTransforms();
    }
}
