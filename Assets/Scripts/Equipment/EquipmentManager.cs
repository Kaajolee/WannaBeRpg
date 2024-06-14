using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Item armorSlot;
    public Item meleeSlot;
    public Item rangedSlot;

    public Material material;

    public EquipmentManager Instance { get; private set; }
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EquipItem(Item itemToEquip, out Item itemToSwap)
    {
        itemToSwap = null;

        switch (itemToEquip.weaponType)
        {
            case Item.WeaponType.TwoHanded:
                itemToSwap = meleeSlot;
                meleeSlot = itemToEquip;
                break;

            case Item.WeaponType.OneHanded:
                itemToSwap = meleeSlot;
                meleeSlot = itemToEquip;
                break;

            case Item.WeaponType.Ranged:
                itemToSwap = rangedSlot;
                rangedSlot = itemToEquip;
                break;

            default:
                Debug.LogWarning("Unknown weapon type: " + itemToEquip.weaponType);
                break;
                //prideti case su armoru
        }

        if(itemToSwap == null)
        {
            Debug.LogError("[EquipmentManager] item to be swapped is null, name: " + itemToSwap.itemName);
        }

    }
    public void ChangeItemMesh(MeshFilter filter, MeshRenderer renderer)
    {
        switch (HotberController.currentSelection)
        {
            //melee
            case 0:
                SetItemMesh(meleeSlot, filter, renderer, false);
                break;
             
            //ranged
            case 1:
                SetItemMesh(rangedSlot, filter, renderer, false);
                break;

            //fireball
            case 2:
                SetItemMesh(meleeSlot, filter, renderer, true);
                break;
        }
    }
    public void SetItemMesh(Item item, MeshFilter filter, MeshRenderer renderer, bool makeInvisible)
    {
        if (!makeInvisible)
        {
            filter.mesh = item.mesh;
            renderer.material = material;
        }
        else
        {
            filter.mesh.Clear();
        }

    }
    
}
