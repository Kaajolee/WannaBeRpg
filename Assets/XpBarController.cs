using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XpBarController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI currentLevelText;
    [SerializeField]
    private TextMeshProUGUI nextLevelText;
    [SerializeField]
    private Slider xpBar;
    void Start()
    {
        UpdateUI();
        GlobalEvents.Instance.OnEnemyKilled += UpdateUI;

        xpBar.maxValue = StatController.Instance.xpRequired;
        xpBar.value = 0;
        xpBar.interactable = false;

    }
    void UpdateUI()
    {
        UpdateLevelText();
        UpdateSlider();
    }
    void UpdateLevelText()
    {
        currentLevelText.text = StatController.Instance.level.ToString();
        nextLevelText.text = (StatController.Instance.level + 1).ToString();
    }
    void UpdateSlider()
    {
        xpBar.value = StatController.Instance.xp;
        xpBar.maxValue = StatController.Instance.xpRequired;
    }
}
