using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemBagUIController : MonoBehaviour
{
    [SerializeField]
    private GameObject UIItemPrefab;
    GameObject ItemBagGO;


    ItemBagDataController BagData;


    void Start()
    {
        ItemBagGO = ReferenceVault.Instance.ItemBagPanel;
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
        ReferenceHolder RH = ItemBagGO.GetComponent<ReferenceHolder>();

        CleanBagUI(RH);

        foreach (var item in BagData.items)
        {
            InstantiateItemInBag(item, RH);
        }
        ShowBagPanel();
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
    void ShowBagPanel()
    {
        TogglePanel(ItemBagGO, true);

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        if (mousePos.x > Screen.width / 2)
            ItemBagGO.transform.position = mousePos + new Vector3(120, 0, 0);
        else
            ItemBagGO.transform.position = mousePos + new Vector3(-120,0,0);
    }
}
