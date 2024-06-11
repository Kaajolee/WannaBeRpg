
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealthController : HealthControllerAbstract
{
    
    private EnemyStatController statController;
    private TaskHolder taskHolder;
    private bool isDead = false;
    public bool isBeingDamaged = false;
    public int maxHealth = 0;


    void Start()
    {
        MaxHealth = maxHealth;
        Health = MaxHealth;
        
        taskHolder = GetComponent<TaskHolder>();
        statController = GetComponent<EnemyStatController>();
    }

    void Update()
    {
        if (!isDead && Health <= 0)
        {
            Die();
            
        }
    }
    public override void Heal(int healAmount)
    {
        Health += healAmount;
        Health = Mathf.Clamp(Health, 0, maxHealth);
        
    }
    public override void Die()
    {
        if (!isDead)
        {
            isDead = true;
            DissolveController dissolve = GetComponent<DissolveController>();
            taskHolder.UpdateQuest();
            MoneyController.instance.EnemyKilled(GetComponent<EnemyStatController>().CalculateMoneyDropAmount());
            dissolve.StartDissolver();
            //Destroy(gameObject);
        }
    }
    public override void TakeDamage(int damageAmount)
    {
        Health -= statController.CalculateDamageTake(damageAmount);
        Debug.Log($"{gameObject.name} hit, current health: {Health}");
        Health = Mathf.Clamp(Health, 0, maxHealth);
    }
    /*public void IsBeingDamaged()
    {
        float currentHp = health;
        
    }*/
}
