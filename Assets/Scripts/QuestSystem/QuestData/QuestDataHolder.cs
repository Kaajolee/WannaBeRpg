using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestDataHolder : MonoBehaviour
{
    public QuestDataScript questData;
    public TextMeshProUGUI textArea;

    public void OnBackGroundClick()
    {
        textArea.text = questData.QuestDescription + "\n\n\n"+
                              $"Money amount: {questData.QuestReward.moneyAmount}\n" +
                              $"Experience amount: {questData.QuestReward.xpAmount}\n";
    }
    public void OnQuestAcceptClick()
    {
        QuestManager.Instance.AcceptQuest(questData);
    }
}
