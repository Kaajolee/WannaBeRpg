using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class CameraTransition : MonoBehaviour
{
    // Start is called before the first frame update
    //public delegate void CameraStoppedEventHandler();
    //public event CameraStoppedEventHandler CameraStopped;

    public Transform characterCreationPoint;
    public Transform optionsPoint;
    public Transform creditsPoint;
    public Transform MainMenuPoint;

    public float transitionTime;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Transition(characterCreationPoint.position, characterCreationPoint.rotation));
        }
    }
    public void MoveCameraTo(Transform whereToMove)
    {
        StartCoroutine(Transition(whereToMove.position, whereToMove.rotation));
    }

    IEnumerator Transition(Vector3 whereToMove, Quaternion rotateTo)
    {
        Vector3 startPos = transform.position;
        Quaternion startRot = transform.rotation;
        float timeElapsed = 0;

        while (timeElapsed < transitionTime)
        {
            float t = timeElapsed / transitionTime;

            transform.position = Vector3.Lerp(startPos, whereToMove, t);
            transform.rotation = Quaternion.Slerp(startRot, rotateTo, t);

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = whereToMove;
        transform.rotation = rotateTo;
        Debug.Log("Camera moved to " + whereToMove);
        Debug.Log("Camera rotated to " + rotateTo);

    }
}
