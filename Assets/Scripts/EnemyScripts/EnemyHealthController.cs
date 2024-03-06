
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    private EnemyStatController statController;
    private bool isDead = false;
    public bool isBeingDamaged = false;


    void Start()
    {
        health = maxHealth;
        statController = GetComponent<EnemyStatController>();
    }

    void Update()
    {
        if (!isDead && health <= 0)
        {
            Die();
            
        }
    }
    public void Heal(int healAmount)
    {
        health += healAmount;
        health = Mathf.Clamp(health, 0, maxHealth);
        
    }
    public void Die()
    {
        if (!isDead)
        {
            isDead = true;
            DissolveController dissolve = GetComponent<DissolveController>();
            dissolve.StartDissolver();
            MoneyController.instance.EnemyKilled(GetComponent<EnemyStatController>().CalculateMoneyDropAmount());
            //Destroy(gameObject);
        }
    }
    public void TakeDamage(int damageAmount)
    {
        health -= statController.CalculateDamageTake(damageAmount);
        Debug.Log($"{gameObject.name} hit, current health: {health}");
        health = Mathf.Clamp(health, 0, maxHealth);
    }
    /*public void IsBeingDamaged()
    {
        float currentHp = health;
        
    }*/
}
