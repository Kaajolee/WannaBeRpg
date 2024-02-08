using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform itemContent;
    public GameObject inventoryItem;

    public Toggle enableRemove;

    public InventoryItemController[] inventoryItems;
    private void Awake()
    {
        Instance = this;
    }
    public void Add(Item item)
    {
        Items.Add(item);
    }
    public void Remove(Item item)
    {
        Items.Remove(item);
    }
    public void ListItems()
    {
        //clean
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }
        //add to panel"


            foreach (var item in Items)
            {
                GameObject obj = Instantiate(inventoryItem, itemContent);
                if (obj != null)
                {
                    var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
                    var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
                    var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();
                    Debug.Log(itemName.text);

                    itemIcon.sprite = item.icon;
                    itemName.text = item.itemName;

                    if (enableRemove.isOn)
                        removeButton.gameObject.SetActive(true);



                }
                else
                    Debug.Log("Item not found");
            }

            SetInventoryItems();
        
    }
    public void EnableItemsRemove()
    {
        if(enableRemove.isOn)
        {
            foreach (Transform item in itemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in itemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(false);
            }
        }
    }
    public void SetInventoryItems()
    {
        inventoryItems = itemContent.GetComponentsInChildren<InventoryItemController>();

        for (int i = 0; i < Items.Count; i++)
        {
            inventoryItems[i].AddItem(Items[i]); 
        }
    }

}
