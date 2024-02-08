using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public GameObject statPanel;
    private TextMeshProUGUI armorText;
    private TextMeshProUGUI strengthText;
    private TextMeshProUGUI dexterityText;
    private TextMeshProUGUI intelligenceText;
    private TextMeshProUGUI meleeWeapDmgText;
    private TextMeshProUGUI rangedWeapDmgText;
    public static StatManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // Cache
        armorText = statPanel.transform.Find("armorText").GetComponent<TextMeshProUGUI>();
        strengthText = statPanel.transform.Find("strengthText").GetComponent<TextMeshProUGUI>();
        dexterityText = statPanel.transform.Find("dexterityText").GetComponent<TextMeshProUGUI>();
        intelligenceText = statPanel.transform.Find("intelligenceText").GetComponent<TextMeshProUGUI>();
        meleeWeapDmgText = statPanel.transform.Find("meleeWeapDmgText").GetComponent<TextMeshProUGUI>();
        rangedWeapDmgText = statPanel.transform.Find("rangedWeapDmgText").GetComponent<TextMeshProUGUI>();
    }

    public void UpdateStatPanel()
    {
        // Update 
        armorText.text = "Armor: " + StatController.Instance.armor;
        strengthText.text = "Strength: " + StatController.Instance.strength;
        dexterityText.text = "Dexterity: " + StatController.Instance.dexterity;
        intelligenceText.text = "Intelligence: " + StatController.Instance.intelligence;
        meleeWeapDmgText.text = "Melee: " + StatController.Instance.GetMeleeDamage();
        rangedWeapDmgText.text = "Ranged: " + StatController.Instance.RweaponDamage;
    }

}
