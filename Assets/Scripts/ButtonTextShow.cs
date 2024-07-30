using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonTextShow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    GameObject textBox;

    public void OnPointerEnter(PointerEventData eventData)
    {
        TextMeshProUGUI text = textBox.GetComponent<TextMeshProUGUI>();
        if (text != null)
        {
            text.text = GetComponentInChildren<ButtonTextHolder>().buttonText;
            textBox.SetActive(true);
            textBox.transform.position = eventData.position;
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textBox.SetActive(false);
    }

    private void Start()
    {
        textBox = ReferenceVault.Instance.buttonTextBox;
    }

}
