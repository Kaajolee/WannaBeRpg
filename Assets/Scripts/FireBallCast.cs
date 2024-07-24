using UnityEngine;

public class FireBallCast : MonoBehaviour
{

    public Transform shootPosition;

    public float fireBallSpeed;
    public float castTime;
    private float currentCastTime;

    private bool isCasting = false;

    public GameObject fireBallPrefab;
    private GameObject instantiatedCastBarObject;

    private UnityEngine.UI.Slider instantiatedCastBarSlider;

    private Animator animator;

    public AudioSource audioSource;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (HotberController.currentSelection == 2)
        {
            if (Input.GetButtonDown("Fire1") && !isCasting)
            {
                StartCasting();
            }
            if (isCasting)
            {
                UpdateCastTimer();
            }
        }
    }
    void ShootFireBall()
    {
        GameObject fireBall = Instantiate(fireBallPrefab, shootPosition.position, Quaternion.identity);

        Rigidbody rb = fireBall.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.velocity = shootPosition.forward * fireBallSpeed * Time.deltaTime;

        Vector3 playerRotation = transform.eulerAngles;
        fireBall.transform.rotation = Quaternion.Euler(new Vector3(0, playerRotation.y, 0));

        PlayFireballSound();
    }
    void StartCasting()
    {
        Transform castBarLocation = GameObject.FindGameObjectWithTag("castBarLocation")?.transform;

        if (castBarLocation != null)
        {
            instantiatedCastBarObject = CastBar.CreateCastBar(castBarLocation);
            //Debug.Log(GameObject.FindGameObjectWithTag("castBarLocation").transform.position);
            instantiatedCastBarSlider = instantiatedCastBarObject.GetComponentInChildren<UnityEngine.UI.Slider>();

            isCasting = true;
            currentCastTime = 0f;
            animator.Play("SpellCast");

            audioSource.clip = SoundVault.Instance.fireBallCastSound;
            audioSource.Play();
        }

    }
    void UpdateCastTimer()
    {
        currentCastTime += Time.deltaTime;

        float castPercentage = Mathf.Clamp01(currentCastTime / castTime);
        instantiatedCastBarSlider.value = castPercentage;

        if (currentCastTime >= castTime)
        {
            FinishCasting();
        }

    }
    void FinishCasting()
    {
        ShootFireBall();
        isCasting = false;
        Destroy(instantiatedCastBarObject);


    }
    void PlayFireballSound()
    {
        AudioClip fireballSound = SoundVault.Instance.GetRandomFireBallSound();
        audioSource.clip = fireballSound;
        audioSource.Play();
    }
}
