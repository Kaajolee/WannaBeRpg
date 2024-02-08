using UnityEngine;

public class KeybindManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject statPanel;
    public GameObject inventoryPanel;
    void Start()
    {

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
            InventoryManager.Instance.ListItems();
            SwitchActive(inventoryPanel);
        }
    }
    private void SwitchActive(GameObject ob)
    {
        ob.SetActive(!ob.activeSelf);
    }
}
