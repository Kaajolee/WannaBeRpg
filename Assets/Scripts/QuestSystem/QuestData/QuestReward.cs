using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest/Create new reward")]
public class QuestReward : ScriptableObject
{
    public Item rewardItem;
    public int moneyAmount;
    public int xpAmount;

    public QuestReward(int moneyAmount, int xpAmount)
    {
        //this.rewardItem = rewardItem;
        this.moneyAmount = moneyAmount;
        this.xpAmount = xpAmount;
    }
}
