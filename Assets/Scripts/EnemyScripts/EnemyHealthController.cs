
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    private EnemyStatController statController;


    void Start()
    {
        health = maxHealth;
        statController = GetComponent<EnemyStatController>();
    }

    void Update()
    {
        if (health <= 0)
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
        DissolveController dissolve = GetComponent<DissolveController>();
        dissolve.StartDissolver();
        //Destroy(gameObject);
    }
    public void TakeDamage(int damageAmount)
    {
        health -= statController.CalculateDamageTake(damageAmount);
        Debug.Log($"{gameObject.name} hit, current health: {health}");
        health = Mathf.Clamp(health, 0, maxHealth);

        

    }
}
