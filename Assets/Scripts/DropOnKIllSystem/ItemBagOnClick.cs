using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemBagDataController : MonoBehaviour
{
    // Start is called before the first frame update
    public delegate void ItemBagDataControllerEventHandler();
    public event ItemBagDataControllerEventHandler OnItemBagClick;
    public Item[] items { get; private set; }
    [SerializeField]
    private int itemAmount;

    //GameObject ItemBagPanel;

    void Start()
    {

    }
    private void OnEnable()
    {
        LoadItems();
    }
    private void OnMouseDown()
    {
        OnItemBagClick?.Invoke();
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
    void MoveItemsToInventory()
    {

    }

}
