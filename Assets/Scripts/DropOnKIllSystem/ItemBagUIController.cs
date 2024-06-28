using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemBagUIController : MonoBehaviour
{
    GameObject ItemBagPanel;
    GameObject UIItemPrefab;

    Transform Canvas;

    Button TakeAllButton;

    ReferenceHolder RH;

    ItemBagDataController BagData;


    void Start()
    {
        ItemBagPanel = ReferenceVault.Instance.ItemBagPanel;
        Canvas = ReferenceVault.Instance.MainCanvas.transform;
        UIItemPrefab = ReferenceVault.Instance.UIItemPrefab;

        BagData = GetComponent<ItemBagDataController>();

        BagData.OnItemBagClick += InstantiateBagUI;
    }
    private void InstantiateItemInBag(Item item, in ReferenceHolder RH)
    {


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
    private void TogglePanel(GameObject panel, bool enabled)
    {
        panel.SetActive(enabled);
    }

    public void InstantiateBagUI()
    {
        GameObject panel;
        InstantiateBagPanel(out panel);
        ReferenceHolder RH = panel.GetComponent<ReferenceHolder>();

        CleanBagUI(RH);

        foreach (var item in BagData.items)
        {
            InstantiateItemInBag(item, RH);
        }
        TogglePanel(panel, true);
    }
    void CleanBagUI(in ReferenceHolder RH)
    {

        foreach (Transform item in RH.ContentGO.transform)
        {
            Destroy(item.gameObject);
        }
    }
    void UpdateBagContent(in ReferenceHolder RH)
    {
        CleanBagUI(RH);

        foreach (var item in BagData.items)
        {
            InstantiateItemInBag(item, RH);
        }
    }
    void InstantiateBagPanel(out GameObject panel)
    {
        panel = Instantiate(ItemBagPanel, Canvas);

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        if (mousePos.x > Screen.width / 2)
            panel.transform.position = mousePos + new Vector3(120, 0, 0);
        else
            panel.transform.position = mousePos + new Vector3(-120,0,0);

        RH = panel.GetComponent<ReferenceHolder>();
    }
}
