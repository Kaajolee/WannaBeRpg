using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBagOnClick : MonoBehaviour
{
    // Start is called before the first frame update

    private Item[] items;
    [SerializeField]
    private int itemAmount;
    void Start()
    {

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
        items = new Item[itemAmount];
        items = ItemDatabase.instance.GetRandomItems(itemAmount);

        if (items.Length == 0)
            Debug.LogWarning("[ItemBagOnClick] DropTable empty");
        else
            Debug.Log("[ItemBagOnClick] Droptable item count: "+ items.Length);
    }

}
