using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
public class ConcreteMediator : QuestManagerMediator
{
    public ConcreteMediator()
    {
        NotStartedQuests = new List<QuestDataScript>();
        ActiveQuests = new List<QuestDataScript>();
        CompletedQuests = new List<QuestDataScript>();
    }

    public override void AddQuest(QuestDataScript quest)
    {
        NotStartedQuests.Add(quest);
    }

    public override void CompleteQuest(QuestDataScript questData)
    {
        QuestDataScript questToFind = ActiveQuests.Find(q => q.QuestName == questData.QuestName);
        if (questToFind != null)
        {
            ActiveQuests.Remove(questToFind);
            CompletedQuests.Add(questData);
        }
    }

    public override void PrintQuests(QuestStatus questStatus)
    {
        switch (questStatus)
        {
                 //Print not started quests
            case QuestStatus.NotStarted:
                PrintList(NotStartedQuests);
                break;

                //Print InProgress quests
            case QuestStatus.InProgress:
                PrintList(ActiveQuests);
                break;

                //Print completed quests
            case QuestStatus.Completed:
                PrintList(CompletedQuests);
                break;
        }
    }

    public override void RemoveQuest(QuestDataScript quest)
    {
        //Remove quest based on its status
        switch (quest.QuestStatus)
        {
            case QuestStatus.NotStarted:
                NotStartedQuests.Remove(quest);
                break;

            case QuestStatus.InProgress:
                ActiveQuests.Remove(quest);
                break;

            case QuestStatus.Completed:
                CompletedQuests.Remove(quest);
                break;
        }

    }
    void PrintList(List<QuestDataScript> list)
    {
        Debug.Log(list[0].QuestStatus.ToString() + " quests\n");
        foreach (var item in list)
        {
            Debug.Log(item.QuestName + "\n");
        }
    }
}
public class Quest : QuestAbstract
{
    private string QuestName;
    private string QuestDescription;
    private QuestStatus QuestStatus;
    public Quest(QuestManagerMediator mediator, string questName, string questDescription, QuestStatus questStatus) : base(mediator)
    {
        this.mediator = mediator;
        QuestName = questName;
        QuestDescription = questDescription;
        QuestStatus = questStatus;
    }

    public override string GetQuestDescription()
    {
        return QuestDescription;
    }

    public override string GetQuestName()
    {
        return QuestName;
    }

    public override QuestStatus GetQuestStatus()
    {
        return QuestStatus;
    }

    public override void SetQuestDescription(string questDescription)
    {
        QuestDescription = questDescription;
    }

    public override void SetQuestName(string questName)
    {
        QuestName = questName;
    }

    public override void SetQuestStatus(QuestStatus status)
    {
        QuestStatus = status;
    }
}

public class TestProgram
{
    public static void Main(string[] args)
    {
        ConcreteMediator mediator = new ConcreteMediator();

        QuestReward reward = new QuestReward(25, 100);

        QuestDataScript quest1 = new QuestDataScript(mediator, "name1", "description1", reward, QuestStatus.NotStarted, QuestObjectiveType.KillEnemies);
        QuestDataScript quest2 = new QuestDataScript(mediator, "name2", "description2", reward, QuestStatus.NotStarted, QuestObjectiveType.DeliverItem);

        mediator.AddQuest(quest1);
        mediator.AddQuest(quest2);

        mediator.PrintQuests(QuestStatus.NotStarted);

        //rezultatas:
        //name1
        //name2
    }
}
