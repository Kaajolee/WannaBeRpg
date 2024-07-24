using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class GlobalEvents : MonoBehaviour
{
    // Start is called before the first frame update
    public static GlobalEvents Instance { get; private set; }

    public delegate void EnemyKilledEventHandler();
    public event EnemyKilledEventHandler OnEnemyKilled;

    void Start()
    {
        Instance = this;
    }
    public void EnemyKilled()
    {
        OnEnemyKilled.Invoke();
        Debug.Log("EnemyKilled event invoked");
    }

}
