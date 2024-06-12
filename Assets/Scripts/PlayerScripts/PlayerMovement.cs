using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController characterController;
    public static bool canMove;
    public static Vector3 playerPosition;
    float horizontal;
    float vertical;
    public float rotationTime;

    public bool isMoving = false;
    public bool isGrounded = true;

    Vector2 currentPosition;
    Vector3 velocityY;

    public AudioSource audioSource;

    public Transform cam;

    public float moveSpeed;
    public float jumpPower;
    public float gravity;
    float turnSmoothness;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector3 playerInput = new Vector3(horizontal, 0, vertical).normalized;

        playerPosition = transform.Find("CharacterPosition").position;

        isGrounded = characterController.isGrounded;


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
            Jump();

        currentPosition = new Vector2(transform.position.x, transform.position.z);
        MoveAndRotate(playerInput);
        characterController.Move(velocityY * Time.deltaTime);
        ApplyGravity();

        Vector2 nextPosition = new Vector2(transform.position.x, transform.position.z);

        if (currentPosition != nextPosition)
            isMoving = true;
        else
            isMoving = false;

        PlayWalkingSound();



    }
    void ApplyGravity()
    {
        velocityY.y -= gravity * Time.deltaTime;
    }
    void Jump()
    {
        velocityY.y = Mathf.Sqrt(2 * jumpPower);

    }
    void MoveAndRotate(Vector3 playerInput)
    {
        if (playerInput.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(playerInput.x, playerInput.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothness, rotationTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //currentPosition = new Vector2(transform.position.x, transform.position.z);
            Debug.DrawRay(transform.position + new Vector3(0,1,0), playerInput);
            characterController.Move(moveDirection.normalized * Time.deltaTime * moveSpeed);
            //characterController.Move(velocityY * Time.deltaTime);
            

            //Vector2 nextPosition = new Vector2(transform.position.x, transform.position.z);

            //if (currentPosition != nextPosition)
            //    isMoving = true;
            //else
            //    isMoving = false;
        }
    }
    void PlayWalkingSound()
    {
        if (isMoving && isGrounded && !audioSource.isPlaying)
        {
            StartCoroutine(PlaySoundWithRandomPitch());
        }
        else if ((!isMoving || !isGrounded) && audioSource.isPlaying)
        {
            audioSource.Stop();
            StopCoroutine(PlaySoundWithRandomPitch());
        }
    }

    IEnumerator PlaySoundWithRandomPitch()
    {
        while (isMoving && isGrounded)
        {
            audioSource.pitch = Random.Range(0.8f, 1.1f);
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
        }
    }

    /*void PlayWalkingSound()
    {
        if(isMoving && !audioSource.isPlaying && isGrounded)
        {
            audioSource.pitch = Random.Range(0.8f, 1.1f);
            audioSource.Play();
        }
            

        else if(!isMoving && audioSource.isPlaying || !isGrounded && audioSource.isPlaying)
            audioSource.Stop();
    }*/
}
