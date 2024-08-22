using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVFXController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private ParticleSystem vfx;
    [SerializeField]
    private int particleCount;
    void Start()
    {
        vfx.Stop();
        GlobalEvents.Instance.OnLevelUp += PlayOnLevelUp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PlayOnLevelUp()
    {
        vfx.Emit(particleCount);

    } 

}
