using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    PlayerMovement playerMovement;
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isRunning", playerMovement.isMoving);
        animator.SetBool("isGrounded", playerMovement.isGrounded);
    }
}
