using Cinemachine;
using UnityEngine;

public class CursorLock : MonoBehaviour
{
    public bool isMouseHeldDown = true;
    public CinemachineFreeLook freeLookCamera;
    void Start()
    {

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        freeLookCamera.m_XAxis.m_InputAxisName = "";
        freeLookCamera.m_YAxis.m_InputAxisName = "";

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            freeLookCamera.m_XAxis.m_InputAxisName = "Mouse X";
            freeLookCamera.m_YAxis.m_InputAxisName = "Mouse Y";
        }

        if(Input.GetMouseButtonUp(1))
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            freeLookCamera.m_XAxis.m_InputAxisName = "";
            freeLookCamera.m_YAxis.m_InputAxisName = "";
            freeLookCamera.m_XAxis.m_InputAxisValue = 0f;
            freeLookCamera.m_YAxis.m_InputAxisValue = 0f;
        }

    }
}
