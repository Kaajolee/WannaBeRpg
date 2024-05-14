using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest/Create new quest")]
public class QuestDataScript : ScriptableObject
{
    public ConcreteMediator Mediator;
    public string QuestName;
    public string QuestDescription;
    public QuestReward QuestReward;
    public QuestStatus QuestStatus;
    public QuestObjectiveType QuestObjectiveType;
    public int QuestObjectiveCount;

    public QuestDataScript(ConcreteMediator mediator, string questName, string questDescription, QuestReward questReward, 
                           QuestStatus questStatus, QuestObjectiveType questObjectiveType, int questObjectiveCount)
    {
        Mediator = mediator;
        QuestName = questName;
        QuestDescription = questDescription;
        QuestReward = questReward;
        QuestStatus = questStatus;
        QuestObjectiveType = questObjectiveType;
        QuestObjectiveCount = questObjectiveCount;
    }

}
