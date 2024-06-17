using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static QuestManager Instance { get; private set; }
    public List<QuestDataScript> AllQuestDataList;
    public ConcreteMediator mediator;
    public Transform ItemContent;
    public Transform ItemContentInProgress;

    public TextMeshProUGUI completedCountLabel;

    public GameObject QuestItemPrefab;
    public GameObject aboutTextArea;
    public GameObject QuestItemPrefabInProgress;

    public delegate void QuestDataChangedEventHandler();
    public event QuestDataChangedEventHandler OnQuestDataChanged;

    void Start()
    {
        mediator = new ConcreteMediator();

        mediator.PopulateQuestLists(AllQuestDataList);
        mediator.ItemContentLog = ItemContent;
        mediator.QuestItemPrefab = QuestItemPrefab;
        mediator.aboutTextArea = aboutTextArea.GetComponent<TextMeshProUGUI>();
        mediator.QuestItemPrefabInProgress = QuestItemPrefabInProgress;
        mediator.ItemContentInProgress = ItemContentInProgress;

        OnQuestDataChanged += RefreshInProgressQuests;

    }
    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //mediator.ListInProgressQuests();
    }
    public void QuestStepUpdate(string questName, QuestObjectiveType questObjectiveType)
    {
        mediator.UpdateQuestStepData(questName, questObjectiveType);
    }
    public void ActiveQuestsClicked()
    {
        mediator.ListQuests(ItemContent, mediator.GetListByStatus(QuestStatus.InProgress));
    }
    public void NotStartedQuestsClicked()
    {
        mediator.ListQuests(ItemContent, mediator.GetListByStatus(QuestStatus.NotStarted));
    }
    public void CompletedQuestsClicked()
    {
        mediator.ListQuests(ItemContent, mediator.GetListByStatus(QuestStatus.Completed));
    }
    public void UpdateCountLabel()
    {
        mediator.UpdateCompletedQuestLabel(completedCountLabel);
    }
    public void AcceptQuest(QuestDataScript questData)
    {
        mediator.AcceptQuest(questData);
        OnQuestDataChanged.Invoke();
    }
    void RefreshInProgressQuests()
    {
        mediator.ListInProgressQuests();
    }
    public void UpdateUI()
    {
        OnQuestDataChanged.Invoke();
    }
}
