using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationStateController : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    NavMeshAI ai;
    void Start()
    {
        animator = GetComponent<Animator>();
        ai = GetComponent<NavMeshAI>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isRunning", ai.isMoving);

    }
}
