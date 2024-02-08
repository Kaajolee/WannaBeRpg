using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAI : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;

    public float detectionRadius;
    public float offset;

    public static bool isMoving;
    public bool isInMeleeRange;

    public float meleeRange;

    Vector3 playerPos;
    Vector2 currentPos;
    Vector2 updatedPos;

    public float positionDifference = 0.001f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerPos = PlayerMovement.playerPosition;
        currentPos = new Vector2(transform.position.x, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = PlayerMovement.playerPosition;
        Move();
        updatedPos = new Vector2(transform.position.x, transform.position.z);


        if (Vector2.Distance(currentPos, updatedPos) > positionDifference)
        {
            //Debug.Log("Position has changed");
            isMoving = true;
            currentPos = updatedPos;
        } 
        else
        {
            //Debug.Log("Position has not changed");
            isMoving = false;
        }
            
    }

    void Move()
    {
        float distance = Vector3.Distance(transform.position, playerPos);

        Vector3 direction  = playerPos - transform.position;

        //Debug.Log(distance);
        if(distance <= detectionRadius)
        {
            //float stoppingDistance = detectionRadius - offset;
            Vector3 targetPosition = playerPos - direction.normalized * offset;

            if (distance < offset)
            {
                agent.ResetPath();
                
            }
            else if (distance <= offset + meleeRange)
                isInMeleeRange= true;
            else
            {
                isInMeleeRange = false;
                agent.SetDestination(targetPosition);
            }
        }
    }
}
