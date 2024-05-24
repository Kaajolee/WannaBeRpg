using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance { get; private set; }

    public GameObject OptionsPanelGO;
    public GameObject CreditsPanelGO;
    public GameObject CreationpanelGO;
    public GameObject MainMenupanelGO;
    public static CameraTransition camTransScript;

    Transform creationTransform;
    Transform optionsTransform;
    Transform creditsTransform;
    Transform mainTransform;

    public Transform canvasTransform;

    private void Start()
    {
        instance = this;
        MainMenupanelGO.SetActive(true);
        OptionsPanelGO.SetActive(false);
        CreditsPanelGO.SetActive(false);
        CreationpanelGO.SetActive(false);

        camTransScript = Camera.main.GetComponent<CameraTransition>();
        creationTransform = camTransScript.characterCreationPoint;
        mainTransform = camTransScript.MainMenuPoint;
        optionsTransform = camTransScript.optionsPoint;
        //creationTransform = camTransScript.creditsPoint;


    }
    public void OptionsMenuSelect()
    {
        Debug.Log("Options button pressed");
        camTransScript.MoveCameraTo(optionsTransform);

        OptionsPanelGO.SetActive(!OptionsPanelGO.activeSelf);
        MainMenupanelGO.SetActive(!MainMenupanelGO.activeSelf);
    }
    public void CreditsMenuSelect()
    {
        Debug.Log("Credits button pressed");
        //camTransScript.MoveCameraTo(creditsTransform);

        CreditsPanelGO.SetActive(!CreditsPanelGO.activeSelf);
        MainMenupanelGO.SetActive(!MainMenupanelGO.activeSelf);
    }
    public void ExitMenuSelect()
    {
        Application.Quit();
    }
    public void StartNewGameMenuSelect()
    {
        Debug.Log("Start Game button pressed");

        camTransScript.MoveCameraTo(creationTransform);
        CreationpanelGO.SetActive(!CreationpanelGO.activeSelf);
        MainMenupanelGO.SetActive(!MainMenupanelGO.activeSelf);
    }
    public void BackButtonSelect()
    {
        GameObject enabled = FindTheOneEnabled();
        if (enabled != null)
        {
            Debug.Log("Back button pressed");

            enabled.SetActive(!enabled.activeSelf);
            MainMenupanelGO.SetActive(!MainMenupanelGO.activeSelf);
            camTransScript.MoveCameraTo(mainTransform);
        }

    }
    GameObject FindTheOneEnabled()
    {
        GameObject go = null;
        foreach (Transform child in canvasTransform)
        {
            if (child.gameObject.activeSelf)
            {
                go = child.gameObject;
                return go;
            }
        }
        return go;
    }
}
