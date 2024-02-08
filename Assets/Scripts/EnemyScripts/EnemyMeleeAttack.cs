using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    Transform attackPoint;
    public float attackRange;
    public LayerMask playerMask;
    Animator animator;
    public float attackSpeed;
    EnemyStatController enemyStatController;
    NavMeshAI navMeshAI;
    private bool isAttacking = false;
    // Start is called before the first frame update
    void Start()
    {
        attackPoint = transform.Find("AttackPoint");
        animator = GetComponent<Animator>();
        enemyStatController = GetComponent<EnemyStatController>();
        navMeshAI = GetComponent<NavMeshAI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAI.isInMeleeRange && !isAttacking)
        {
            StartCoroutine(Attack());
        }
        else if (!navMeshAI.isInMeleeRange)
        {
            StopAllCoroutines();
            isAttacking = false;
        }
    }
    IEnumerator Attack()
    {
        isAttacking = true;
        while (navMeshAI.isInMeleeRange)
        {

            yield return new WaitForSeconds(attackSpeed);

            Collider[] hitColliders = Physics.OverlapSphere(attackPoint.position, attackRange, playerMask);
            foreach (Collider player in hitColliders)
            {

                HealthController playerhealth = player.gameObject.GetComponent<HealthController>();
                DoDamage(playerhealth);
                //Debug.Log("Melee attack hit, name: " + player.name);

            }
            if (Random.Range(0, 2) == 1)
            {
                animator.Play("PunchLeft");
            }
            else
                animator.Play("PunchRight");
        }
        isAttacking = false;
        
    }
    void DoDamage(HealthController playerhealth)
    {
        bool isCrit;
        int damage = enemyStatController.CalculateAttackDamage(out isCrit);
        GameObject gameObj = playerhealth.gameObject;
        if (isCrit)
        {
            playerhealth.TakeDamage(damage);
            DamagePopUp.Create(gameObj.transform.position, damage, isCrit, gameObj.tag);
        }
        else
        {
            playerhealth.TakeDamage(damage);
            DamagePopUp.Create(gameObj.transform.position, damage, isCrit, gameObj.tag);
        }
    }
}
