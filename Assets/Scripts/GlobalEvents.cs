using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class GlobalEvents : MonoBehaviour
{
    // Start is called before the first frame update
    public static GlobalEvents Instance { get; private set; }

    public delegate void GameEventHandler();

    public event GameEventHandler OnEnemyKilled;
    public event GameEventHandler OnQuestCompleted;
    public event GameEventHandler OnLevelUp;
    public event GameEventHandler OnDamageTaken;

    void Start()
    {
        Instance = this;
    }
    public void EnemyKilled()
    {
        OnEnemyKilled?.Invoke();
        Debug.Log("EnemyKilled event invoked");
    }
    public void QuestCompleted()
    {
        OnQuestCompleted?.Invoke();
        Debug.Log("QuestCompleted event invoked");
    }
    public void LevelUp()
    {
        OnLevelUp?.Invoke();
        Debug.Log("OnLevelUp event invoked");
    }
    public void DamageTaken()
    {
        OnDamageTaken?.Invoke();
        Debug.Log("OnDamageTaken event invoked");
    }

}
