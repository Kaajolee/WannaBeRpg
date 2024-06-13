using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource musicPlayer;
    AudioClip musicClip;
    void Start()
    {
        musicClip = SoundVault.Instance.GetMusicClip();
        PlayMusic();
    }
    void PlayMusic()
    {
        musicPlayer.clip = musicClip;
        musicPlayer.Play();
    }
}
