using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestManagerMediator
{
    protected List<QuestAbstract> NotStartedQuests { get;  set; }
    protected List<QuestAbstract> ActiveQuests { get;  set; }
    protected List<QuestAbstract> CompletedQuests { get;  set; }

    public QuestManagerMediator()
    {
        NotStartedQuests = new List<QuestAbstract>();
        ActiveQuests = new List<QuestAbstract>();
        CompletedQuests = new List<QuestAbstract>();
    }
    public abstract void AddQuest(QuestAbstract quest); 
    public abstract void RemoveQuest(QuestAbstract quest); 
    public abstract void CompleteQuest(QuestAbstract quest);
    public abstract void PrintNotStartedQuests();
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
public enum TaskStatus
{
    NotStarted,
    InProgress,
    Completed
}

