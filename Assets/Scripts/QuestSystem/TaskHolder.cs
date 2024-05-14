using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskHolder : MonoBehaviour
{
    // Start is called before the first frame update
    public TaskData taskData;
    public void UpdateQuest()
    {
        if (taskData != null)
        {
            if(taskData.objectiveType == QuestObjectiveType.KillEnemies)
            {
                QuestManager.Instance.QuestStepUpdate(taskData.QuestName, taskData.objectiveType);
            }
        }
        else
            Debug.Log("Task data null");
    }
}
