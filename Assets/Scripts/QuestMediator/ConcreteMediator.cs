using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ConcreteMediator : QuestManagerMediator
{

    public override void AddQuest(QuestAbstract quest)
    {
        NotStartedQuests.Add(quest);
    }

    public override void CompleteQuest(QuestAbstract quest)
    {
        Quest questToFind = ActiveQuests.Find(q => q.GetQuestName() == quest.GetQuestName()) as Quest;
        if (questToFind != null)
        {
            ActiveQuests.Remove(questToFind);
            CompletedQuests.Add(quest);
        }
    }

    public override void PrintNotStartedQuests()
    {
        foreach (var item in NotStartedQuests)
        {
            Console.WriteLine(item.GetQuestName()+ "\n");
        }
    }

    public override void RemoveQuest(QuestAbstract quest)
    {
        Quest questToRemoveNotStarted = NotStartedQuests.Find(q => q.GetQuestName() == quest.GetQuestName()) as Quest;

        Quest questToRemoveActive = ActiveQuests.Find(q => q.GetQuestName() == quest.GetQuestName()) as Quest;

        Quest questToRemoveCompleted = CompletedQuests.Find(q => q.GetQuestName() == quest.GetQuestName()) as Quest;


        if(questToRemoveNotStarted != null)
            NotStartedQuests.Remove(questToRemoveNotStarted);

        if (questToRemoveActive != null)
            ActiveQuests.Remove(questToRemoveNotStarted);

        if (questToRemoveCompleted != null)
            CompletedQuests.Remove(questToRemoveNotStarted);
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

        Quest quest1 = new Quest(mediator, "name1", "description1", QuestStatus.NotStarted);
        Quest quest2 = new Quest(mediator, "name2", "description2", QuestStatus.NotStarted);

        mediator.AddQuest(quest1);
        mediator.AddQuest(quest2);

        mediator.PrintNotStartedQuests();

        //rezultatas:
        //name1
        //name2
    }
}
