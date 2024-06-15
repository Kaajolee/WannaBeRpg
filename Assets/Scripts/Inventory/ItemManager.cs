using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static ItemManager Instance { get; private set; }

    public delegate void InventoryDataChangeEventHandler();

    public event InventoryDataChangeEventHandler OnInventoryDataChange;

    public Inventory inventory;
    void Start()
    {
        Instance = this;

        inventory = GetComponent<Inventory>();
    }
    public void OnItemClicked(PhysicalItem Item)
    {
        Item item = ItemDatabase.instance.GetItemByID(Item.ID);

        if (item != null)
        {
            // prideti i inventoriu
            inventory.AddItem(item);
            OnInventoryDataChange.Invoke();
            Destroy(Item.gameObject);
        }
        else
            Debug.LogError("[Item Manager] item ID not found in the DB, ID: " + Item.ID);
    }
    public void EquipItem(UIItemID item)
    {
        //gauti itemo data is DB
        Item itemdata = ItemDatabase.instance.GetItemByID(item.ID);
        inventory.EquipItem(itemdata);

        //equipinti itema
        Item itemToSwap;
        EquipmentManager.Instance.EquipItem(itemdata, out itemToSwap);

        //jei ne null, perkelti i kita data lista
        if(itemToSwap != null)
        inventory.UnequipItem(itemToSwap);

        OnInventoryDataChange.Invoke();
    }
    public void UnequipItem(UIItemID item)
    {
        Item itemdata = ItemDatabase.instance.GetItemByID(item.ID);
        inventory.UnequipItem(itemdata);
    }

}
