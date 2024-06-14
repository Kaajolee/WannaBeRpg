using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallDamage : MonoBehaviour
{
    public int baseDamage;
    public float destroyTime;
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            EnemyHealthController enemyHealthController = collision.gameObject.GetComponent<EnemyHealthController>();

            if (enemyHealthController != null)
                DoDamage(enemyHealthController);
        }

        else if(collision.gameObject.tag != "player")
        Destroy(gameObject);

        

    }
    void DoDamage(EnemyHealthController enemyHealthController)
    {
        enemyHealthController.TakeDamage(baseDamage);
        DamagePopUp.Create(enemyHealthController.transform.position, baseDamage, false, enemyHealthController.gameObject.tag);
        Destroy(gameObject);
    }
    private void OnEnable()
    {
        Destroy(gameObject, destroyTime);
    }
}
