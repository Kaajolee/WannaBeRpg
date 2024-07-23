using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    // Start is called before the first frame update

    public static ItemDatabase instance;

    List<Item> itemData = new List<Item>();
    void Start()
    {
        instance = this;
        itemData = Resources.LoadAll<Item>("ItemDataFolder").ToList();

        Debug.Log("[ItemDatabase] Items loaded - " + itemData.Count);
    }
    public Item GetItemByID(int ID)
    {
        foreach (var item in itemData)
        {
            if (item.id == ID)
            {
                
                return item;
            }
                
        }
        return null;
    }
    public List<Item> GetRandomItems(int amount)
    {

        if (amount <= 0)
            return null;

        List<Item> itemArray = new List<Item>();

        if (amount == 1)
        {
            itemArray.Add(GetItemByID(Random.Range(0, itemData.Count)));
            return itemArray;
        }

        for (int i = 0; i < amount; i++)
        {
            int index = Random.Range(0, itemData.Count);
            itemArray.Add(GetItemByID(index));
        }

        return itemArray;
    }
}
