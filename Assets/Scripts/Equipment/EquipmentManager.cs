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

    public GameObject jointItemGO;

    MeshFilter meshFilter;
    MeshRenderer meshRenderer;
    public static EquipmentManager Instance { get; private set; }

    EquipmentUIManager equipmentUIManager;
    void Start()
    {
        Instance = this;

        meshFilter = jointItemGO.GetComponent<MeshFilter>();
        meshRenderer = jointItemGO.GetComponent<MeshRenderer>();
        equipmentUIManager = GetComponent<EquipmentUIManager>();
        
        if (meshFilter == null)
            Debug.LogError("[EquipmentManager] MeshFilter is null");

        if (meshRenderer == null)
            Debug.LogError("[EquipmentManager] MeshRenderer is null");
    }

    // Update is called once per frame
    void Update()
    {
        ChangeItemMesh(meshFilter, meshRenderer);
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

        equipmentUIManager.ChangeSprite(itemToEquip);


    }
    public void ChangeItemMesh(MeshFilter filter, MeshRenderer renderer)
    {
        switch (HotberController.currentSelection)
        {
            //melee
            case 0:
                if(meleeSlot != null)
                    SetItemMesh(meleeSlot, filter, renderer, false);
                break;
             
            //ranged
            case 1:
                if (rangedSlot != null)
                    SetItemMesh(rangedSlot, filter, renderer, false);
                break;

            //fireball
            case 2:
                if (meleeSlot != null)
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
