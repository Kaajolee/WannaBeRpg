using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedUIItemID : MonoBehaviour
{
    public int ID;
    public void OnItemClicked()
    {
        ReferenceVault.Instance.ItemBagPanel.GetComponent<ReferenceHolder>().CurrentItemDropGO.GetComponent<ItemBagDataController>().MoveItem(ID);
    }
    private void OnEnable()
    {
        
    }
}
