using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemBagOnClick : MonoBehaviour
{
    // Start is called before the first frame update

    private Item[] items;
    [SerializeField]
    private int itemAmount;

    GameObject ItemBagPanel;
    GameObject UIItemPrefab;
    Transform Canvas;
    Button TakeAllButton;
    ReferenceHolder RH;

    void Start()
    {
        ItemBagPanel = ReferenceVault.Instance.ItemBagPanel;
        Canvas = ReferenceVault.Instance.MainCanvas.transform;
        UIItemPrefab = ReferenceVault.Instance.UIItemPrefab;
    }
    private void OnEnable()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        LoadItems();
    }
    private void LoadItems()
    {
        Random.Range(0, 3);
        items = new Item[itemAmount];
        items = ItemDatabase.instance.GetRandomItems(itemAmount);

        if (items.Length == 0)
            Debug.LogWarning("[ItemBagOnClick] DropTable empty");
        else
            Debug.Log("[ItemBagOnClick] Droptable item count: "+ items.Length);


        TogglePanel(true);
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

            itemName.text = item.name;
            itemImage.sprite = item.icon;
            uiItemInstance.GetComponent<InventoryUIItemID>().ID = item.id;
        }
        else
            Debug.LogError("[InventoryUIController] instantiated item is null");
    }
    private void TogglePanel(bool enabled)
    {
        ItemBagPanel.SetActive(enabled);
    }
    private void SubscribeToButtonClick(Button button)
    {
        button.onClick.AddListener(MoveItemsToInventory);
    }
    void MoveItemsToInventory()
    {

    }
    
    void UpdateBagUI()
    {
        foreach (var item in items)
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
