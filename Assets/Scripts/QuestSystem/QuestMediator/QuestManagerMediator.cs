using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestManagerMediator
{
    protected List<QuestDataScript> NotStartedQuests { get;  set; }
    protected List<QuestDataScript> ActiveQuests { get;  set; } // cia
    protected List<QuestDataScript> CompletedQuests { get;  set; }
    public abstract void AddQuest(QuestDataScript quest); 
    public abstract void RemoveQuest(QuestDataScript quest); 
    public abstract void CompleteQuest(QuestDataScript quest);
    public abstract void PrintQuests(QuestStatus questStatus);
}
public abstract class QuestAbstract
{
    protected QuestManagerMediator mediator;
    public QuestAbstract(QuestManagerMediator mediator)
    {
        this.mediator = mediator;
    }

    public abstract string GetQuestName();
    public abstract string GetQuestDescription();
    public abstract QuestStatus GetQuestStatus();
    public abstract void SetQuestName(string questName);
    public abstract void SetQuestDescription(string questDescription);
    public abstract void SetQuestStatus(QuestStatus status);
}
public enum QuestStatus
{
    NotStarted,
    InProgress,
    Completed
}
public enum QuestObjectiveType
{
    KillEnemies,
    DeliverItem,
    Destination
}

