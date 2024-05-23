using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

    public GameObject resDropDownGO;
    public GameObject screenTypeDropDownGO;

    public AudioMixer audioMixer;

    TMP_Dropdown resDropDown;
    TMP_Dropdown screenTypeDropDown;

    int width;
    int height;

    void Start()
    {
        resDropDown = resDropDownGO.GetComponent<TMP_Dropdown>();
        screenTypeDropDown = screenTypeDropDownGO.GetComponent<TMP_Dropdown>();

        width = 1920;
        height = 1080;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ApplySettings()
    {
        ApplyResolution();
        ApplyScreenType();
        ApplySound();
        MainMenu.instance.BackButtonSelect();
    }
    public void BackButtonPressed()
    {
        MainMenu.instance.BackButtonSelect();
    }
        
    void ApplyResolution()
    { 
        switch (resDropDown.value)
        {
            case 0:
                width = 1920;
                height = 1080;
                break;
            case 1:
                width = 1600;
                height = 900;
                break;
            case 2:
                width = 1366;
                height = 768;
                break;

        }
        Screen.SetResolution(width, height, Screen.fullScreen);
        Debug.Log($"Resolution set to {width}x{height}");
    }
    void ApplyScreenType()
    {
        switch (screenTypeDropDown.value)
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                Debug.Log($"ScreenType set to FullScreenWindow");
                break;
            case 1:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                Debug.Log($"ScreenType set to Windowed");
                break;
        }
    }
    void ApplySound() 
    {
        float volumeDb = Mathf.Log10(masterVolumeSlider.value) * 20;
        audioMixer.SetFloat("Volume", volumeDb);
        Debug.Log($"Volume set to: {volumeDb}DB");

    }
}
