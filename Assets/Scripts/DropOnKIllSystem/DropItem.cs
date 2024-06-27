using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItems : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject itemBagPrefab;

    void Start()
    {

    }
    public void DropItemOnGround()
    {
        GameObject ob = Instantiate(itemBagPrefab, transform.position, Quaternion.identity); 
    }
}
