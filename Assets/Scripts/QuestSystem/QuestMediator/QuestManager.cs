using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static QuestManager Instance { get; private set; }
    public List<QuestDataScript> AllQuestDataList;
    private ConcreteMediator mediator;
    void Start()
    {
        mediator = new ConcreteMediator();
        mediator.PopulateQuestLists(AllQuestDataList);
    }
    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void QuestStepUpdate(string questName, QuestObjectiveType questObjectiveType)
    {
        mediator.UpdateQuestStepData(questName, questObjectiveType);
    }
}
