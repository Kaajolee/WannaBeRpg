using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIItemID : MonoBehaviour
{
    public int ID;

    public void EquipItem()
    {
        ItemManager.Instance.EquipItem(this);
    }
}
