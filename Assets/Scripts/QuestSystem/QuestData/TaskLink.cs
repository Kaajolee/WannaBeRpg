using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Task", menuName = "Quest/Create new task")]
public class TaskLink : ScriptableObject
{
    public string QuestName;
    public QuestObjectiveType objectiveType;
    
}
