using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create new item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int value;
    public Sprite icon;
    public ItemType itemType;
    public WeaponType weaponType;
    public GameObject prefab;


    public enum ItemType
    {
        healthPotion,
        manaPotion,
        weapon
    }
    public enum WeaponType
    {
        None,
        TwoHanded,
        OneHanded,
        Ranged
    }
}
