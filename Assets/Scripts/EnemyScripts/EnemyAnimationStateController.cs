using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationStateController : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    public bool isMoving;
    void Start()
    {
        animator = GetComponent<Animator>();
        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        isMoving = NavMeshAI.isMoving;
        animator.SetBool("isRunning", isMoving);

    }
}
