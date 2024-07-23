using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedUIItemID : MonoBehaviour
{
    public int ID;
    GameObject parent;
    public void OnItemClicked()
    {
        ItemManager.Instance.AddItemToInventory(ItemDatabase.instance.GetItemByID(ID));
    }
    private void OnEnable()
    {
        parent = transform.parent.gameObject;
    }
}
