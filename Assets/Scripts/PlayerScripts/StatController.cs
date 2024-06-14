using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StatController : MonoBehaviour
{
    public static StatController Instance;
    public int armor;
    public int strength;
    public int dexterity;
    public int intelligence;

    public int MweaponDamage;
    public int RweaponDamage;

    public int level;
    public int xp;
    public int baseXpReward;
    public float critChance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        //MweaponDamage = EquipController.equipedWeapon.value;
    }
    private void Update()
    {
        //MweaponDamage = EquipController.equipedWeapon.value;
    }
    public int CalculateMeleeAttackDamage(out bool isCrit)
    {
        //MweaponDamage = EquipController.equipedWeapon.value;
        int damage;
        if (UnityEngine.Random.Range(0,5) == 1)
        {
           damage = (int)Math.Round(MweaponDamage + strength * 0.5f + MweaponDamage * 0.5f);
            isCrit = true;
        }
        else
        {
            damage = (int)Math.Round(MweaponDamage + strength * 0.5f);
            isCrit = false;
        }
            


        return damage;
    }
    public int GetMeleeDamage()
    {   int damage;
        damage = (int)Math.Round(MweaponDamage + strength * 0.5f);
        return damage;
    }
    public float CalculateRangedAttackDamage()
    {
        return RweaponDamage + dexterity * 0.5f;
    }
    public int CalculateDamageTake(int enemyAttackDamage)
    {
        float damageTaken;
        damageTaken = enemyAttackDamage - (armor * 0.8f);
        Mathf.Clamp(damageTaken, 0, enemyAttackDamage);
        int newDamageTaken = (int)Math.Round(damageTaken);
        return newDamageTaken;
    }
    
    public void GainXp(int enemyLevel)
    {
        double gainedXp;
        gainedXp = baseXpReward * Math.Pow(1.1, enemyLevel - level);
        int roundedXp = (int)Math.Round(gainedXp);
        
        xp += roundedXp;

        LevelUp();
    }
    public void LevelUp()
    {
        if(xp >= 100)
        {
            level++;
            xp = xp - 100;
        }
    }
    public void AddArmor(int value)
    {
        armor += value;
    }
    public void AddStrength(int value)
    {
        strength += value;
    }
    public void AddDexterity(int value)
    {
        dexterity += value;
    }
    public void AddIntelligence(int value)
    {
        intelligence += value;
    }
}
