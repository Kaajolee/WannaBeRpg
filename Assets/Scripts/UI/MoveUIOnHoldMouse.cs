using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveUIOnHoldMouse : MonoBehaviour
{
    // Start is called before the first frame update
    RectTransform canvasObject;
    EventTrigger trigger;
    void Start()
    {
        canvasObject = GetComponentInParent<RectTransform>();

        trigger = gameObject.GetComponent<EventTrigger>();

        if (trigger == null)
            trigger = gameObject.AddComponent<EventTrigger>();


        EventTrigger.Entry dragEntry = new EventTrigger.Entry
        {
            eventID = EventTriggerType.Drag
        };

        dragEntry.callback.AddListener((data) => { MoveObject(data); });

        trigger.triggers.Add(dragEntry);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void MoveObject(BaseEventData data)
    {

        PointerEventData pointerData = (PointerEventData)data;
        Vector2 localPoint;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasObject, pointerData.position, null, out localPoint);

        transform.position = canvasObject.transform.TransformPoint(localPoint);
    }
}
