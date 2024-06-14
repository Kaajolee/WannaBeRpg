using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Item> inventoryItems;
    public List<Item> equipedItems;
    void Start()
    {
        inventoryItems = new List<Item>();
    }

    public void AddItem(Item item)
    {
        inventoryItems.Add(item);

        Debug.Log("[Inventory] item added, name - "+ item.itemName);
    }
    public void RemoveItem(Item item)
    {
        if (inventoryItems.Contains(item))
        {
            inventoryItems.Remove(item);

            Debug.Log("[Inventory] item removed, name - " + item.itemName);
        }
        else
            Debug.LogError("[Inventory] item is not in the inventory, name - " + item.itemName);
    }
    public void EquipItem(Item item)
    {
        inventoryItems.Remove(item);
        equipedItems.Add(item);
    }
    public void UnequipItem(Item item)
    {
        inventoryItems.Add(item);
        equipedItems.Remove(item);
    }
}
