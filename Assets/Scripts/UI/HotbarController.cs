using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class HotberController : MonoBehaviour
{
    public GameObject hotbar;
    GameObject[] hotbarItems;
    public float transparent;
    public float notTransparent;
    public static int currentSelection = 0;
    void Start()
    {
        ChildGet(out hotbarItems);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentSelection = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentSelection = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentSelection = 2;
        }
        ChangeTransparency();

    }
    void ChildGet(out GameObject[] hotbarItems)
    {

        Transform parentTransform = hotbar.transform;
        hotbarItems = new GameObject[parentTransform.childCount];
        int i = 0;
        foreach (Transform child in parentTransform)
        {
            hotbarItems[i] = child.gameObject;
            i++;
        }
    }
    void ChangeTransparency()
    {
        for (int i = 0; i < hotbarItems.Length; i++)
        {
            ChangeIndividualTransparency(hotbarItems[i], transparent);
        }
        ChangeIndividualTransparency(hotbarItems[currentSelection], notTransparent);

    }
    void ChangeIndividualTransparency(GameObject item, float value)
    {

        Image background = item.transform.Find("background").GetComponent<Image>();
        Image weaponLogo = item.transform.Find("Image").GetComponent<Image>();
        TextMeshProUGUI number = item.transform.Find("Number").GetComponent<TextMeshProUGUI>();

        //BACKGROUND
        Color bgColor = background.color;
        bgColor.a = value;
        background.color = bgColor;

        //WEAPON LOGO
        Color bgColorWeapon = weaponLogo.color;
        bgColorWeapon.a = value;
        weaponLogo.color = bgColorWeapon;

        //SLOTNUMBER
        Color bgColorNumber = number.color;
        bgColorNumber.a = value;
        number.color = bgColorNumber;

    }


}
