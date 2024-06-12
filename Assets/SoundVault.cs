using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVault : MonoBehaviour
{
    // Start is called before the first frame update
    public static SoundVault Instance;

    public List<AudioClip> meleeSoundList;
    public List<AudioClip> fireballSoundList;

    public AudioClip fireBallCastSound;
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioClip GetRandomMeleeSound()
    {
        int index = (int)Random.Range(0, meleeSoundList.Count);

        return meleeSoundList[index];
    }
    
    public AudioClip GetRandomFireBallSound()
    {
        int index = (int)Random.Range(0, fireballSoundList.Count);

        return fireballSoundList[index];
    }
}
