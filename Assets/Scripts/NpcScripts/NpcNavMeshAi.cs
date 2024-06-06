using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcNavMeshAi : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent aiAgent;
    public Transform centerTransform;
    public float wanderRadius;
    public float wanderCooldown;
    void Start()
    {
        aiAgent = GetComponent<NavMeshAgent>();
        StartCoroutine(MoveNpc());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator MoveNpc()
    {
        while (true)
        {
            Vector3 nextPos = CalculateNextPosition(centerTransform.position, -1);

            aiAgent.SetDestination(nextPos);
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
}
