using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcNavMeshAi : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent aiAgent;
    Animator npcAnim;
    public Transform centerTransform;
    public float wanderRadius;
    public float wanderCooldown;
    public bool isMoving;
    void Start()
    {
        aiAgent = GetComponent<NavMeshAgent>();
        npcAnim = GetComponent<Animator>();

        isMoving = false;
        StartCoroutine(MoveNpc());

    }

    // Update is called once per frame
    void Update()
    {
        MovementDetector();
        SetAnimationBooleans();
    }
    IEnumerator MoveNpc()
    {
        while (true)
        {
            Vector3 nextPos = CalculateNextPosition(centerTransform.position, -1);

            aiAgent.SetDestination(nextPos);
            isMoving = true;
            yield return new WaitForSeconds(wanderCooldown);

        }
    }
    Vector3 CalculateNextPosition(Vector3 centerPos, int areaMask)
    {
        Vector3 nextPos = Random.insideUnitSphere * wanderRadius;

        nextPos += centerPos;

        NavMeshHit hit;


        if (NavMesh.SamplePosition(nextPos, out hit, wanderRadius, areaMask))
        {
            return hit.position;
        }
        return centerPos;

    }
    void MovementDetector()
    {
        if (aiAgent.velocity.magnitude > new Vector3(0, 0, 0).magnitude)
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
    void SetAnimationBooleans()
    {
        npcAnim.SetBool("isRunning", isMoving);
    }
}
