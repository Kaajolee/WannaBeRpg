using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    // Start is called before the first frame update
    private Item itemToDrop;
    void Start()
    {
        itemToDrop = ItemDatabase.instance.GetItemByID(1);
    }
    public void DropItemOnGround()
    {
        GameObject ob = Instantiate(itemToDrop.prefab, transform.position, transform.rotation) ;
        
    }
}
