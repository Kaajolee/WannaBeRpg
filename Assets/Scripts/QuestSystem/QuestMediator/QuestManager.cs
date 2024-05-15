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
    public Transform ItemContent;
    public Transform ItemContentInProgress;

    public GameObject QuestItemPrefab;
    public GameObject aboutTextArea;
    public GameObject QuestItemPrefabInProgress;

    void Start()
    {
        mediator = new ConcreteMediator();
        mediator.PopulateQuestLists(AllQuestDataList);
        mediator.ItemContentLog = ItemContent;
        mediator.QuestItemPrefab = QuestItemPrefab;
        mediator.aboutTextArea = aboutTextArea.GetComponent<TextMeshProUGUI>();
        mediator.QuestItemPrefabInProgress = QuestItemPrefabInProgress;
        mediator.ItemContentInProgress = ItemContentInProgress;
        StartCoroutine(RefreshInPRogressQuests());
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
    IEnumerator RefreshInPRogressQuests()
    {
        while (true)
        {
            mediator.ListInProgressQuests();
            yield return new WaitForSeconds(1);
        }
    }
}
