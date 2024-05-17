using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        PlayMainMenuMusic();
    }
    private void OnDisable()
    {
        StopMainMenuMusic();
    }

    public void PlayMainMenuMusic()
    {
        audioSource.loop = true;

        Debug.Log("Main menu music started playing");
    }
    public void StopMainMenuMusic()
    {
        audioSource.Stop();
        Debug.Log("Main menu music stopped playing");
    }
}
