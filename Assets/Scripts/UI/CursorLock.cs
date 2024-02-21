using Cinemachine;
using UnityEngine;

public class CursorLock : MonoBehaviour
{
    private bool isLocked = true;
    public CinemachineFreeLook freeLookCamera;
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
            freeLookCamera.m_XAxis.m_InputAxisName = "";
            freeLookCamera.m_YAxis.m_InputAxisName = "";
        }
        else if(isLocked == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            freeLookCamera.m_XAxis.m_InputAxisName = "x";
            freeLookCamera.m_YAxis.m_InputAxisName = "y";
        }
    }
}
