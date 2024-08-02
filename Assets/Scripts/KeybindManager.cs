using UnityEngine;

public class KeybindManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject statPanel;
    public GameObject inventoryPanel;
    public GameObject questPanel;
    public GameObject performancePanel;
    public GameObject characterPanel;
    public Canvas canvas;
    private void Start()
    {
        canvas = ReferenceVault.Instance.MainCanvas;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            StatManager.Instance.UpdateStatPanel();
            SwitchActive(statPanel);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            SwitchActive(inventoryPanel);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            SwitchActive(questPanel);
            QuestManager.Instance.UpdateCountLabel();
            QuestManager.Instance.ActiveQuestsClicked();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            SwitchActive(performancePanel);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            SwitchActive(characterPanel);
        }
        if(Input.GetKeyDown(KeyCode.BackQuote))
        {
            SwitchActive(canvas.gameObject);
        }
    }
    private void SwitchActive(GameObject ob)
    {
        ob.SetActive(!ob.activeSelf);
    }
}
