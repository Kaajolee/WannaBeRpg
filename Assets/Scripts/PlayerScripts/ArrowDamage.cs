using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDamage : MonoBehaviour
{
    public int baseDamage;
    public int lifeTimeDurtation;
    private void OnCollisionEnter(Collision collision)
    {
        EnemyHealthController enemyHealthController = collision.gameObject.GetComponent<EnemyHealthController>();

        if (enemyHealthController != null)
            DoDamage(enemyHealthController);
        
    }
    void DoDamage(EnemyHealthController enemyHealthController)
    {
            DamagePopUp.Create(enemyHealthController.transform.position, baseDamage, false, enemyHealthController.gameObject.tag);
            enemyHealthController.TakeDamage(baseDamage);
            Destroy(gameObject, lifeTimeDurtation);
    }
    
}
