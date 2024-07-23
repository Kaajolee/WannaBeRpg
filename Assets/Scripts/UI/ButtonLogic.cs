using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLogic : MonoBehaviour
{
    
    void Start()
    {
        
    }

    public void OnCloseClicked()
    {
        gameObject.SetActive(false);
        
    }
    public void OnTakeAllClicked()
    {
        MoveAllItems();
    }
    public void MoveAllItems()
    {
        ReferenceHolder rh = GetComponentInParent<ReferenceHolder>();
        rh.CurrentItemDropGO.GetComponent<ItemBagDataController>().MoveAllItemsToInventory();
        rh.scrollbar.value = 1;
        Destroy(rh.CurrentItemDropGO);
        gameObject.SetActive(false);
    }
}
