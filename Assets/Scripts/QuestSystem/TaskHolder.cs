using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskHolder : MonoBehaviour
{
    // Start is called before the first frame update
    public TaskLink checker;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        if (checker != null)
        {
            if(checker.objectiveType == QuestObjectiveType.KillEnemies)
            {

            }
        }
    }
}
