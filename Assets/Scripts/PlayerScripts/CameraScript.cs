using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float rotationSpeed;
    private Vector3 mousePosition;
    private bool isRotating;
    private float horizontalInput;
    private float verticalInput;

    void Start()
    {

    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        HandleInput();

        UpdateCameraState();

        transform.rotation *= Quaternion.AngleAxis(horizontalInput * rotationSpeed, Vector3.up);

    }
    void HandleInput()
    {
        if(Input.GetMouseButtonDown(1))
        {
            isRotating = true;
            mousePosition = Input.mousePosition;
        }
        if(Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }
    }
    void UpdateCameraState()
    {
        if(isRotating)
        {
            RotateCamera();
        }
    }
    void RotateCamera()
    {
        Vector3 deltaMouse = Input.mousePosition - mousePosition;
        float rotationX = deltaMouse.x * rotationSpeed * Time.deltaTime;
        float rotationY = deltaMouse.y * rotationSpeed * Time.deltaTime;
        transform.RotateAround(PlayerMovement.playerPosition, Vector3.up, rotationX);
        transform.RotateAround(PlayerMovement.playerPosition, Vector3.up, rotationY);

        mousePosition = Input.mousePosition;
    }
}
