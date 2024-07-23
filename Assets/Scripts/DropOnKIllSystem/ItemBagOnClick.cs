using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemBagDataController : MonoBehaviour
{
    // Start is called before the first frame update
    public delegate void ItemBagDataControllerEventHandler();
    public event ItemBagDataControllerEventHandler OnItemBagClick;

    public List<Item> items { get; private set; }
    [SerializeField]
    private int itemAmount;

    ItemBagUIController itemBagUIController;

    private void OnEnable()
    {
        LoadItems();
    }
    private void OnMouseDown()
    {
        OnItemBagClick?.Invoke();
    }
    private void Start()
    {
        itemBagUIController = GetComponent<ItemBagUIController>();
    }
    private void LoadItems()
    {
        //Random.Range(0, 3);

        items = ItemDatabase.instance.GetRandomItems(itemAmount);

        if (items.Count == 0)
            Debug.LogWarning("[ItemBagOnClick] DropTable empty");
        else
            Debug.Log("[ItemBagOnClick] Droptable item count: "+ items.Count);
        
    }
    public void MoveItem(int itemID)
    {
        foreach (var item in items)
        {
            if(item.id == itemID)
            {
                ItemManager.Instance.inventory.AddItem(item);
                items.Remove(item);
                itemBagUIController.UpdateBagContent();
                LastItemCheck();
                break;
            }
        }
    }
    public void MoveAllItemsToInventory()
    {
        foreach (Item item in items)
        {
            ItemManager.Instance.inventory.AddItem(item);
        }
        items.Clear();
    }
    void LastItemCheck()
    {
        if(items.Count == 0)
        {
            itemBagUIController.LastItemClickedInBag();
        }
    }

}
