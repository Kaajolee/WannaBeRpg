using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemBagUIController : MonoBehaviour
{
    [SerializeField]
    private GameObject UIItemPrefab;
    GameObject ItemBagGO;


    ItemBagDataController BagData;
    ReferenceHolder RH;

    void Start()
    {
        ItemBagGO = ReferenceVault.Instance.ItemBagPanel;
        RH = ItemBagGO.GetComponent<ReferenceHolder>();
        BagData = GetComponent<ItemBagDataController>();

        BagData.OnItemBagClick += InstantiateBagUI;
    }
    private void InstantiateItemInBag(Item item)
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
        RH.CurrentItemDropGO = gameObject;

        CleanBagUI();

        foreach (var item in BagData.items)
        {
            InstantiateItemInBag(item);
        }
        ShowBagPanel();
    }
    void CleanBagUI()
    {

        foreach (Transform item in RH.ContentGO.transform)
        {
            Destroy(item.gameObject);
        }
    }
    public void UpdateBagContent()
    {
        CleanBagUI();

        foreach (var item in BagData.items)
        {
            InstantiateItemInBag(item);
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
    public void LastItemClickedInBag()
    {
        TogglePanel(ItemBagGO, false);
        Destroy(gameObject);
    }
}
