using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemBagUIController : MonoBehaviour
{
    GameObject ItemBagPanel;
    GameObject UIItemPrefab;

    Transform Canvas;

    Button TakeAllButton;

    ReferenceHolder RH;

    ItemBagOnClick BagOnClick;


    void Start()
    {
        ItemBagPanel = ReferenceVault.Instance.ItemBagPanel;
        Canvas = ReferenceVault.Instance.MainCanvas.transform;
        UIItemPrefab = ReferenceVault.Instance.UIItemPrefab;

        BagOnClick = GetComponent<ItemBagOnClick>();
    }
    private void InstantiateBagUI(Item item)
    {
        GameObject go = Instantiate(ItemBagPanel, Canvas);
        RH = go.GetComponent<ReferenceHolder>();

        GameObject uiItemInstance = Instantiate(UIItemPrefab, RH.ContentGO.transform);

        if (uiItemInstance != null)
        {
            TextMeshProUGUI itemName = uiItemInstance.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            Image itemImage = uiItemInstance.transform.Find("ItemIcon").GetComponent<Image>();
            //SubscribeToButtonClick(uiItemInstance.GetComponent<Button>());


            itemName.text = item.name;
            itemImage.sprite = item.icon;
            uiItemInstance.GetComponent<DroppedUIItemID>().ID = item.id;
        }
        else
            Debug.LogError("[InventoryUIController] instantiated item is null");
    }
    private void TogglePanel(bool enabled)
    {
        ItemBagPanel.SetActive(enabled);
    }

    void UpdateBagUI()
    {
        CleanBagUI();

        foreach (var item in BagOnClick.items)
        {
            InstantiateBagUI(item);
        }
    }
    void CleanBagUI()
    {
        foreach (Transform item in RH.ContentGO.transform)
        {
            Destroy(item.gameObject);
        }
    }
}
