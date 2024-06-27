using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemBagOnClick : MonoBehaviour
{
    // Start is called before the first frame update

    public Item[] items { get; private set; }
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

    }

    private void SubscribeToButtonClick(Button button)
    {
        button.onClick.AddListener(MoveItemsToInventory);
    }
    void MoveItemsToInventory()
    {

    }

}
