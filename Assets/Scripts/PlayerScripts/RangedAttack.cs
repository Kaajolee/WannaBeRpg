using System.Collections;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject arrowPrefab;
    public Transform shootPosition;
    public float arrowSpeed;
    public float arrowSpeedMultiplyer;
    //public float arrowLifeDuration;
    public float attackSpeed;

    private float nextTimeFrame;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (HotberController.currentSelection == 1 && Time.time > nextTimeFrame)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                animator.Play("BowShot");
                Shoot();
                nextTimeFrame = Time.time + 1f / attackSpeed;
            }
        }
    }
    void Shoot()
    {
        if (arrowPrefab != null)
        {
            GameObject projectile = Instantiate(arrowPrefab, shootPosition.position, Quaternion.identity);

            Rigidbody rb = projectile.GetComponent<Rigidbody>();

            rb.velocity = shootPosition.forward * arrowSpeed * Time.deltaTime * arrowSpeedMultiplyer;

            Vector3 playerRotation = transform.eulerAngles;
            projectile.transform.rotation = Quaternion.Euler(new Vector3(90f, playerRotation.y, 0f));
        }
    }
}
