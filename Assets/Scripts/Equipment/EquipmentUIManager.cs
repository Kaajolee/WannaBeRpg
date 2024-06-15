using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUIManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Image armorSlotImage;
    public Image meleeSlotImage;
    public Image rangedSlotImage;

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
                break;
            case Item.WeaponType.OneHanded:
                ChangeIndividualSprite(meleeSlotImage, item.icon);
                break;
            case Item.WeaponType.TwoHanded:
                ChangeIndividualSprite(meleeSlotImage, item.icon);
                break;
        }
    }
}
