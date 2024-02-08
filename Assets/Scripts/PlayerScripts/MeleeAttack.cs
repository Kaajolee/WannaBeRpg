using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 15;
    private Animator animator;
    public float attackCooldown;
    private float lastInputTime;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time <= lastInputTime + attackCooldown)
            return;
        if (Input.GetKeyDown(KeyCode.Mouse0) && HotberController.currentSelection ==0)
        {
            Attack();

            lastInputTime = Time.time;
        }

    }
    void Attack()
    {
            PlayerMovement.canMove = true;
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
            foreach (Collider enemy in hitEnemies)
            {
                EnemyHealthController enemyhealth = enemy.gameObject.GetComponent<EnemyHealthController>();
                CalculateCritAndPopUp(enemyhealth);
                //Debug.Log("Melee attack hit, name: " + enemy.name);
                //Debug.Log("Enemy level: " + enemy.GetComponent<EnemyStatController>().enemyLevel);

            }
            PlayAccordingMeleeAnimation();
        
    }
    void CalculateCritAndPopUp(EnemyHealthController enemyhealth)
    {
        int damage = StatController.Instance.CalculateMeleeAttackDamage(out bool isCrit);
        GameObject gameObj = enemyhealth.gameObject;
        Vector3 position = gameObj.transform.position;
        Debug.Log(isCrit);
        if (isCrit)
        {
            enemyhealth.TakeDamage(damage);
            DamagePopUp.Create(position, damage, true, gameObj.tag);
        }
        else
        {
            enemyhealth.TakeDamage(damage);
            DamagePopUp.Create(position, damage, false, gameObj.tag);
        }
    }
    void PlayAccordingMeleeAnimation()
    {
        try
        {
            Item.WeaponType equipedWeaponType = EquipController.equipedWeapon.weaponType;
            switch (equipedWeaponType)
            {
                case Item.WeaponType.None:

                    break;
                case Item.WeaponType.TwoHanded:
                    animator.Play("MeleeAttack_TwoHanded");
                    break;
                case Item.WeaponType.OneHanded:
                    animator.Play("MeleeAttack_OneHanded");
                    break;
                case Item.WeaponType.Ranged:
                    break;
            }
        }
        catch(NullReferenceException e)
        {
            if (UnityEngine.Random.Range(0, 2) == 1)
            {
                animator.Play("PunchLeft");
            }
            else
                animator.Play("PunchRight");
        }
    }

    
}
