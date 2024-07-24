using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyAndLevelUI : MonoBehaviour
{
    public GameObject panelGO;
    private TextMeshProUGUI[] texts;
    private void Start()
    {
        texts = panelGO.GetComponentsInChildren<TextMeshProUGUI>();

        GlobalEvents.Instance.OnEnemyKilled += UpdateTexts;
        UpdateTexts();
    }
    // Update is called once per frame
    void Update()
    {

    }
    void UpdateTexts()
    {
        foreach (TextMeshProUGUI text in texts)
        {
            switch (text.tag)
            {
                case "moneyText":
                    text.text = MoneyController.instance.totalMoney.ToString();
                    break;
                case "xpText":
                    text.text = StatController.Instance.xp.ToString();
                    break;
                case "questText":
                    text.text = 25.ToString();
                    break;
                case "levelText":
                    text.text = StatController.Instance.level.ToString();
                    break;

            }
        }
    }
}
