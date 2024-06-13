using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject uiItemPrefab;
    public GameObject uiContentWindow;

    Inventory inventory;
    void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadUIItems()
    {
        CleanUI();

        foreach (var item in inventory.inventoryItems)
        {
            InstantiateItem(item);
        }
    }
    void InstantiateItem(Item item)
    {
        GameObject uiItemInstance = Instantiate(uiItemPrefab, uiContentWindow.transform);

        if (uiItemPrefab != null)
        {
            TextMeshProUGUI itemName = uiItemInstance.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            Image itemImage = uiItemInstance.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.name;
            itemImage.sprite = item.icon;
            uiItemInstance.GetComponent<UIItemID>().ID = item.id;
        }
        else
            Debug.LogError("[InventoryUIController] instantiated item is null");
    }
    void CleanUI()
    {
        foreach (Transform item in uiContentWindow.transform)
        {
            Destroy(item.gameObject);
        }
    }
}
