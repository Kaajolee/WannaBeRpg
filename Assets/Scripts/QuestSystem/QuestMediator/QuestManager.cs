using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // Start is called before the first frame update
    public QuestManager Instance { get; private set; }
    private ConcreteMediator mediator;
    void Start()
    {
        Instance = this;
        mediator = new ConcreteMediator();
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
