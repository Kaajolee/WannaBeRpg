using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthControllerAbstract : MonoBehaviour
{
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public abstract void TakeDamage(int damageAmount);
    public abstract void Die();
    public abstract void Heal(int healAmount);

}
