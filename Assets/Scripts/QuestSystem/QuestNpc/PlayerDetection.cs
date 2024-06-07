using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isPlayerInRange;
    public float detectionRadius;

    Collider[] colliders;

    Transform canvas;

    PanelToggle questGiverPanelToggle;

    QuestGiverLogic giverLogic;

    void Start()
    {
        isPlayerInRange = false;
        canvas = transform.Find("TextBubbleCanvas");

        if (canvas == null)
        {
            Debug.LogError($"[{transform.gameObject.name}] - canvas is null");
        }

        questGiverPanelToggle = GetComponent<PanelToggle>();
        giverLogic = GetComponent<QuestGiverLogic>();
    }

    // Update is called once per frame
    void Update()
    {


        //DetectColliders();
    }
    private void OnMouseDown()
    {
        Debug.Log($"[{transform.gameObject.name}] - player clicked the collider");
        questGiverPanelToggle.TogglePanel();
        giverLogic.ListQuestsToContent();
    }
    private void OnMouseEnter()
    {
        canvas.gameObject.SetActive(true);
    }
    private void OnMouseExit()
    {
        canvas.gameObject.SetActive(false);
    }

    void DetectColliders()
    {
        colliders = Physics.OverlapSphere(transform.position, detectionRadius);

        foreach (var collider in colliders)
        {
            if (collider.gameObject.tag == "player")
            {
                isPlayerInRange = true;
                Debug.Log($"[{transform.gameObject.name}] - player collider detected");
                break;
            }
            isPlayerInRange = false;
        }
    }
}
