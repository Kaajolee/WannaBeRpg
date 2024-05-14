using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static QuestManager Instance { get; private set; }
    public List<QuestDataScript> AllQuestDataList;
    private ConcreteMediator mediator;
    public GameObject QuestItemPrefab;
    public Transform ItemContent;
    public GameObject aboutTextArea;
    void Start()
    {
        mediator = new ConcreteMediator();
        mediator.PopulateQuestLists(AllQuestDataList);
        mediator.ItemContent = ItemContent;
        mediator.QuestItemPrefab = QuestItemPrefab;
        mediator.aboutTextArea = aboutTextArea.GetComponent<TextMeshProUGUI>();
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
    public void ActiveQuestsClicked()
    {
        mediator.ListQuests(QuestStatus.InProgress);
    }
    public void NotStartedQuestsClicked()
    {
        mediator.ListQuests(QuestStatus.NotStarted);
    }
    public void CompletedQuestsClicked()
    {
        mediator.ListQuests(QuestStatus.Completed);
    }
    public void AcceptQuest(QuestDataScript questData)
    {
        mediator.AcceptQuest(questData);
    }
}
