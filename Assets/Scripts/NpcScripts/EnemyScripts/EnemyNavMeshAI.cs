using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAI : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
    EnemyHealthController enemyHealthController;
    public float detectionRadius;
    public float offset;

    public bool isMoving;
    public bool isInMeleeRange;
    private bool isAttacking;
    public float meleeRange;

    Vector3 playerPos;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerPos = PlayerMovement.playerPosition;
        isAttacking = GetComponent<EnemyMeleeAttack>().isAttacking;
        enemyHealthController = GetComponent<EnemyHealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = PlayerMovement.playerPosition;
        DetectPlayer();

        IsMoving();
            
        

    }

    void DetectPlayer()
    {
        float distance = Vector3.Distance(transform.position, playerPos);

        Vector3 direction  = playerPos - transform.position;
        //Debug.Log(distance);
        if(distance <= detectionRadius)
        {
            Vector3 targetPosition = playerPos - direction.normalized * offset;
            Move(distance, targetPosition);
        }
    }
    void MoveWhenHit()
    {
        if (!isAttacking && enemyHealthController) 
        {
            Vector3 direction = playerPos - transform.position;
        }
    }
    void Move(float distance, Vector3 targetPosition)
    {
        if (distance < offset)
        {
            agent.ResetPath();

        }
        else if (distance <= offset + meleeRange)
            isInMeleeRange = true;
        else
        {
            isInMeleeRange = false;
            agent.SetDestination(targetPosition);
        }
    }
    void IsMoving()
    {
        if (agent.velocity.magnitude > new Vector3(0, 0, 0).magnitude)
        {
            //Debug.Log("pasikeite");
            isMoving = true;
        }
        else
        {
            //Debug.Log("nepasikeite");
            isMoving = false;
        }
    }
}
