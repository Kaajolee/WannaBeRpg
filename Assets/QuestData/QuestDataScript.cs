using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest/Create new quest")]
public class QuestDataScript : ScriptableObject
{
    public string QuestName;
    public string QuestDescription;
    public QuestStatus QuestStatus;


}
