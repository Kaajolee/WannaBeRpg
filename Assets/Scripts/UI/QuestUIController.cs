using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestUIController : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CleanQuestList(Transform itemContent)
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }
    }
    public void ListQuests(GameObject questPrefab, List<QuestDataScript> questList)
    {
        var questName = questPrefab.transform.Find("QuestName").GetComponent<TextMeshProUGUI>();

        foreach (var item in questList)
        {
            
        }
    }
}
