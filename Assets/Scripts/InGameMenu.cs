using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject EscCanvas;
    public GameObject UICanvas;
    void Start()
    {
        EscCanvas.SetActive(false);
        UICanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            GamePaused();
            Cursor.visible = !Cursor.visible;
        }
    }
    public void GamePaused()
    {
        EscCanvas.SetActive(!EscCanvas.activeSelf);
        UICanvas.SetActive(!UICanvas.activeSelf);
        Time.timeScale = EscCanvas.activeSelf ? Time.timeScale = 0f : 1f;
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void QuitButtonPressed()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(0);
    }
    public void OptionsButtonPressed()
    {

    }
    public void LoadGameButtonPressed()
    {

    }
    public void SaveGameButtonPressed()
    {

    }
}
