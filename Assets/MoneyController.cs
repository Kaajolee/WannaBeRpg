using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoneyController : MonoBehaviour
{
    // Start is called before the first frame update
    public static MoneyController instance;
    public int totalMoney = 0;
    private void Awake()
    {
        instance = this;
    }
    void IncreaseMoney(int amount)
    {
        totalMoney += amount;
    }
    void DecreaseMoney(int amount)
    {
        totalMoney -= amount;
    }
    public void EnemyKilled(int moneyToAdd)
    {
        IncreaseMoney(moneyToAdd);
    }
    public void PlayerDied()
    {
        DecreaseMoney(totalMoney/2);
    }
    
}
