using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatController : MonoBehaviour
{
    public int armor = 0;
    public int damageModifier = 3;
    public int dexterity = 1;
    public int intelligence = 1;

    public int weaponDamage = 10;

    public int enemyLevel = 1;

    public int CalculateAttackDamage(out bool isCrit)
    {
        int damage;
        if(UnityEngine.Random.Range(0, 5) == 1)
        {
            damage = (int)Math.Round(weaponDamage + weaponDamage * 1.2f);
            isCrit = true;
        }
        else
        {
            damage = (int)Math.Round(weaponDamage + weaponDamage * 0.4f);
            isCrit = false;
        }
        
        return damage;
    }
    public int CalculateDamageTake(int enemyAttackDamage)
    {
        float damageTaken;
        damageTaken = enemyAttackDamage - (armor * 0.8f);
        Mathf.Clamp(damageTaken, 0, enemyAttackDamage);
        int newDamageTaken = (int)Math.Round(damageTaken);
        return newDamageTaken;
    }
    public int CalculateMoneyDropAmount()
    {
        return enemyLevel * 2 + GetComponent<EnemyHealthController>().maxHealth / 10;
    }
}
