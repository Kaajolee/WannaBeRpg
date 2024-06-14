using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUsage : MonoBehaviour
{
    public ItemUsage Instance;

    private void Start()
    {
        Instance = this;
    }
    public void UseItem(Item item)
    {
        switch (item.itemType) 
        {
            case Item.ItemType.weapon:
                
                break;

            case Item.ItemType.consumable:
                // papildyt logika (dabar nera tokio itemo)
                break;
        }
    }
}
