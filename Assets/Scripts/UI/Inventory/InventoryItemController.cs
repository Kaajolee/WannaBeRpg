using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    Item item;

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);
        Destroy(gameObject);
    }
    public void AddItem(Item newItem)
    {
        item = newItem;
    }
    public void UseItem()
    {
        
        //try
        //{
            switch (item.itemType)
            {
                case Item.ItemType.healthPotion:
                    HealthController.instance.Heal(item.value);
                    break;
                case Item.ItemType.manaPotion:
                    break;
                case Item.ItemType.weapon:
                    Equip(item);
                    break;
                default:
                    Debug.Log("itemType not found");
                    break;
            }
            RemoveItem();
        //}
        //catch(Exception e)
        //{
        //    Debug.LogWarning("Item type is invalid");
        //    Debug.Log(e);
        //}
            
        
    }
    public void Equip(Item item)
    {
        //Debug.Log("aaaaa");
        
        EquipController.SetItem(item);
    }
}
