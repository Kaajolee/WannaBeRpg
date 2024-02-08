using TMPro;
using UnityEngine;

public class HealthController : MonoBehaviour
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
    public void Heal(int healAmount)
    {
        health += healAmount;
        health = Mathf.Clamp(health, 0, maxHealth);
        //healthText.text = $"HP:{health}";
    }
    public void Die()
    {
        Destroy(gameObject);
    }
    public void TakeDamage(int damageAmount)
    {
        health -= StatController.Instance.CalculateDamageTake(damageAmount);
        Debug.Log($"{gameObject.name} hit, current health: {health}");
        health = Mathf.Clamp(health, 0, maxHealth);
        //healthText.text = $"HP:{health}";
    }
}
