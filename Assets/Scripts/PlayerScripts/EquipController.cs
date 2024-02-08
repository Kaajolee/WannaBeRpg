using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EquipController : MonoBehaviour
{
    static MeshRenderer meshRenderer;
    static MeshFilter meshFilter;
    public GameObject whereToPlace;
    private Item baseEquipedItem; //No weapon/hands
    public static Item equipedWeapon;
    private void Start()
    {

        UnarmedWeaponCreate(out baseEquipedItem);
        equipedWeapon = baseEquipedItem;
        meshRenderer = whereToPlace.GetComponent<MeshRenderer>();
        meshFilter = whereToPlace.GetComponent<MeshFilter>();
    }

    public static void SetItem(Item item)
    {
        equipedWeapon = item;
        //Debug.Log(equipedWeapon);

        meshRenderer.sharedMaterial = item.prefab.GetComponent<MeshRenderer>().sharedMaterial;
        meshFilter.sharedMesh = item.prefab.GetComponent<MeshFilter>().sharedMesh;
    }
    void UnarmedWeaponCreate(out Item hands)
    {
        Item item = (Item)ScriptableObject.CreateInstance("Item");
        item.value = 0;
        item.weaponType = Item.WeaponType.None;
        item.itemType = Item.ItemType.weapon;
        hands = item;
    }
}
