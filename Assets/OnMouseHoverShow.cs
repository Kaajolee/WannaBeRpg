using UnityEngine;
using UnityEngine.EventSystems;

public class OnMouseHoverShow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject whatToShow;
    private void Start()
    {
        whatToShow.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse hovered over: " + whatToShow.name);
        whatToShow.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse exited: " + whatToShow.name);
        whatToShow.SetActive(false);
    }
}
