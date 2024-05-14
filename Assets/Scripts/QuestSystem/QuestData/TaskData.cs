using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Task", menuName = "Quest/Create new task")]
public class TaskData : ScriptableObject
{
    public string QuestName;
    public QuestObjectiveType objectiveType;
    
}
