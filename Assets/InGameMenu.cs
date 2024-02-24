using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject EscCanvas;
    public GameObject UICanvas;
    private bool isMenuOpen;
    void Start()
    {
        isMenuOpen = false;
        EscCanvas.SetActive(false);
        UICanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            EscapeButtonPressed();
            Cursor.visible = !Cursor.visible;
        }
    }
    public void EscapeButtonPressed()
    {
        EscCanvas.SetActive(!EscCanvas.activeSelf);
        UICanvas.SetActive(!UICanvas.activeSelf);
        isMenuOpen = EscCanvas.activeSelf;
        Time.timeScale = EscCanvas.activeSelf ? Time.timeScale = 0f : 1f;
    }
}
