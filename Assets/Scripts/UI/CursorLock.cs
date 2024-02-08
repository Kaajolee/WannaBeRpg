using UnityEngine;

public class CursorLock : MonoBehaviour
{
    private bool isLocked = true;
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            ToggleCursorLock();
        }
    }
    private void ToggleCursorLock()
    {
        if (isLocked)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
