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

    public bool isMoving;
    public bool isInMeleeRange;

    public float meleeRange;

    Vector3 playerPos;
    Vector2 currentPos;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerPos = PlayerMovement.playerPosition;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = PlayerMovement.playerPosition;
        currentPos = new Vector2(transform.position.x, transform.position.z);
        Move();

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
