using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject OptionsPanelGO;
    public GameObject CreditsPanelGO;
    private void Start()
    {
        OptionsPanelGO.SetActive(false);
        CreditsPanelGO.SetActive(false);
    }
    public void OptionsMenuSelect()
    {
        Debug.Log("Options button pressed");
        OptionsPanelGO.SetActive(!OptionsPanelGO.activeSelf);
    }
    public void CreditsMenuSelect()
    {
        Debug.Log("Credits button pressed");
        CreditsPanelGO.SetActive(!CreditsPanelGO.activeSelf);
    }
    public void ExitMenuSelect()
    {
        Application.Quit();
    }
    public void StartNewGameMenuSelect()
    {
        SceneManager.LoadScene("Geimas");
    }
}
