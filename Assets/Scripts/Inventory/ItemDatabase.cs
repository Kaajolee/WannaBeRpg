using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    // Start is called before the first frame update

    public static ItemDatabase instance;

    List<Item> items = new List<Item>();
    void Start()
    {
        instance = this;
        items = Resources.LoadAll<Item>("ItemDataFolder").ToList();

        Debug.Log("[ItemDatabase] Items loaded - " + items.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Item GetItemByID(int ID)
    {
        foreach (var item in items)
        {
            if(item.id == ID)
                return item;
        }

        return null;
    }
}
