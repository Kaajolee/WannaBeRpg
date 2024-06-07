using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestGiverLogic : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform notStartedContentGO;
    public Transform inProgressContentGO;

    public GameObject questDisplayPrefab;

    public List<QuestDataScript> notStartedQuestDataList;
    public List<QuestDataScript> inProgressQuestDataList;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CleanContent(Transform contentWindow)
    {
        foreach (Transform item in contentWindow)
        {
            Destroy(item.gameObject);
        }
    }
    public void ListQuestsToContent()
    {
        CleanContent(inProgressContentGO);
        CleanContent(notStartedContentGO);

        QuestManager.Instance.mediator.ListQuests(notStartedContentGO, notStartedQuestDataList);
        QuestManager.Instance.mediator.ListQuests(inProgressContentGO, inProgressQuestDataList);


    }
    
}
