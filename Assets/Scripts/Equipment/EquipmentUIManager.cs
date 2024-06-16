using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUIManager : MonoBehaviour
{
    public delegate void EquipmentUIUpdateEventHandler();

    public event EquipmentUIUpdateEventHandler OnEquipmentUIUpdated;
    // Start is called before the first frame update

    public Image armorSlotImage;
    public Image meleeSlotImage;
    public Image rangedSlotImage;

    public TextMeshProUGUI armorInfoText;
    public TextMeshProUGUI meleeInfoText;
    public TextMeshProUGUI rangedInfoText;

    private void Start()
    {

    }
    void ChangeIndividualSprite(Image image, Sprite changeTo)
    {
        Color color = new Color(image.color.r, image.color.g, image.color.b, 1);

        image.color = color;
        image.transform.localScale = new Vector3(2f,1.2f,1f);
        image.sprite = changeTo;
    }
    public void ChangeSprite(Item item)
    {
        switch (item.weaponType)
        {
            case Item.WeaponType.Ranged:
                ChangeIndividualSprite(rangedSlotImage, item.icon);
                ChangeWeaponText(rangedInfoText, item);
                break;
            case Item.WeaponType.OneHanded:
                ChangeIndividualSprite(meleeSlotImage, item.icon);
                ChangeWeaponText(meleeInfoText, item);
                break;
            case Item.WeaponType.TwoHanded:
                ChangeIndividualSprite(meleeSlotImage, item.icon);
                ChangeWeaponText(meleeInfoText, item);
                break;
        }

    }
    void ChangeWeaponText(TextMeshProUGUI text, Item itemData)
    {
        if (itemData != null)
            text.text = $"{itemData.itemName}\nDamage - {itemData.value}";
        else
            text.text = "No item equipped";
    }
    void ChangeArmorText(TextMeshProUGUI text, Item itemData)
    {
        if (itemData != null)
            text.text = $"{itemData.itemName}\nArmor - {itemData.value}";
        else
            text.text = "No item equipped";
    }
    public void OnUIUpdate()
    {
        OnEquipmentUIUpdated.Invoke();
    }
}
