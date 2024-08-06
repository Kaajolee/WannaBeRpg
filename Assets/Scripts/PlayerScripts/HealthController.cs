using TMPro;
using UnityEngine;

public class PlayerHealthController : HealthController
{

    public static HealthController instance;

    public int health;
    public int maxHealth = 100;

    void Start()
    {
        health = maxHealth;
    }
    private void Awake()
    {
        instance = this;
    }


    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }
    public override void Heal(int healAmount)
    {
        health += healAmount;
        health = Mathf.Clamp(health, 0, maxHealth);
        //healthText.text = $"HP:{health}";
    }
    public override void Die()
    {
        Destroy(gameObject);
    }
    public override void TakeDamage(int damageAmount)
    {
        health -= StatController.Instance.CalculateDamageTake(damageAmount);
        Debug.Log($"{gameObject.name} hit, current health: {health}");
        health = Mathf.Clamp(health, 0, maxHealth);

        GlobalEvents.Instance.DamageTaken();
        //healthText.text = $"HP:{health}";
    }
}
