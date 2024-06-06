using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEditor;
using UnityEngine;


public class ConcreteMediator : Mediator
{
    public GameObject QuestItemPrefab;
    public GameObject QuestItemPrefabInProgress;

    public Transform ItemContentLog;
    public Transform ItemContentInProgress;

    public TextMeshProUGUI aboutTextArea;
    public ConcreteMediator()
    {
        NotStartedQuests = new List<QuestDataScript>();
        ActiveQuests = new List<QuestDataScript>();
        CompletedQuests = new List<QuestDataScript>();
    }

    public override void AddQuest(QuestDataScript quest)
    {
        switch (quest.QuestStatus)
        {
            case QuestStatus.NotStarted:
                NotStartedQuests.Add(quest);
                break;

            case QuestStatus.InProgress:
                ActiveQuests.Add(quest);
                break;

            case QuestStatus.Completed:
                CompletedQuests.Add(quest);
                break;
        }
    }
    public override void AcceptQuest(QuestDataScript quest)
    {
        QuestDataScript questToFind = NotStartedQuests.Find(q => q.QuestName == quest.QuestName);
        if (questToFind != null)
        {
            NotStartedQuests.Remove(questToFind);

            quest.QuestStatus = QuestStatus.InProgress;
            ActiveQuests.Add(quest);

            Debug.Log($"Quest accepted, Name: {quest.QuestName}");
        }
    }
    public override void PopulateQuestLists(List<QuestDataScript> allQuestList)
    {
        foreach (var quest in allQuestList)
        {
            AddQuest(quest);
        }
    }

    public override void CompleteQuest(QuestDataScript questData)
    {
        QuestDataScript questToFind = ActiveQuests.Find(q => q.QuestName == questData.QuestName);
        if (questToFind != null)
        {
            ActiveQuests.Remove(questToFind);

            questData.QuestStatus = QuestStatus.Completed;
            CompletedQuests.Add(questData);

            Debug.Log($"Quest completed, Name: {questData.QuestName}");
        }
    }
    public override QuestDataScript FindQuestByName(string questName)
    {
        QuestDataScript questToFind = NotStartedQuests
                        .Concat(ActiveQuests)
                        .Concat(CompletedQuests)
                        .FirstOrDefault(q => q.QuestName == questName);

        return questToFind;

    }
    public List<QuestDataScript> FindListByStatus(QuestStatus questStatus)
    {
        List<QuestDataScript> list = new List<QuestDataScript>();
        switch (questStatus)
        {
            case QuestStatus.NotStarted:
                list = NotStartedQuests;
                break;

            case QuestStatus.InProgress:
                list = ActiveQuests;
                break;

            case QuestStatus.Completed:
                list = CompletedQuests;
                 break;
        }
        return list;
    }
    public override void UpdateQuestStepData(string questName, QuestObjectiveType objectiveType)
    {
        QuestDataScript questData = FindQuestByName(questName);

        if(questData.QuestObjectiveType == QuestObjectiveType.KillEnemies)
        {
            if(questData.QuestObjectiveCount > 0)
            {
                FindQuestByName(questName).QuestObjectiveCount--;
                Debug.Log($"Quest step updated, questName: {questName}");

                if (FindQuestByName(questName).QuestObjectiveCount == 0)
                    CompleteQuest(questData);
            }
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
    public override void ListQuests(QuestStatus questStatus)
    {
        CleanUI(ItemContentLog);

        List<QuestDataScript> questList = FindListByStatus(questStatus);

        foreach (var quest in questList)
        {
            GameObject obj = Instantiate(QuestItemPrefab, ItemContentLog);

            if(obj != null)
            {
                var questName = obj.transform.Find("QuestName").GetComponent<TextMeshProUGUI>();
                var buttonPanel = obj.transform.Find("ButtonPanel");

                var acceptButton = buttonPanel.transform.Find("AcceptQuestButton");
                var declineButton = buttonPanel.transform.Find("DeclineQuestButton");


                switch (quest.QuestStatus) // iskelti visa switcha i metoda nes nx atrodo
                {
                    case QuestStatus.NotStarted:
                        acceptButton.gameObject.SetActive(true);
                        declineButton.gameObject.SetActive(false);
                        break;

                    case QuestStatus.InProgress:
                        acceptButton.gameObject.SetActive(false);
                        declineButton.gameObject.SetActive(true);
                        break;

                    case QuestStatus.Completed:
                        acceptButton.gameObject.SetActive(false);
                        declineButton.gameObject.SetActive(false);
                        break;
                }


                obj.GetComponent<QuestDataHolder>().questData = quest;
                obj.GetComponent<QuestDataHolder>().textArea = aboutTextArea;

                questName.text = quest.QuestName;
            }

        }

    }
    public void ListInProgressQuests()
    {
        CleanUI(ItemContentInProgress);

        List<QuestDataScript> questList = FindListByStatus(QuestStatus.InProgress);

        int i = 1;

        foreach (var quest in questList)
        {
            GameObject obj = Instantiate(QuestItemPrefabInProgress, ItemContentInProgress);

            if (obj != null)
            {
                var questName = obj.transform.Find("QuestName").GetComponent<TextMeshProUGUI>();
                var questIndex = obj.transform.Find("QuestIndex").GetComponent<TextMeshProUGUI>();

                questName.text = quest.QuestName;
                questIndex.text = $"{i++}.";

            }

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
    void CleanUI(Transform itemContent)
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }
    }
    int CalculateTotalQuests()
    {
        int total = 0;
        total = ActiveQuests.Count + CompletedQuests.Count + NotStartedQuests.Count;
        return total;
    }
    public void UpdateCompletedQuestLabel(TextMeshProUGUI completedCountLabel)
    {
        completedCountLabel.text = $"Completed Quests {CompletedQuests.Count}/{CalculateTotalQuests()}";
    }
}