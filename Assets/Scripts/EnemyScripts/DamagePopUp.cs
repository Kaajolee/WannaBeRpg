using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DamagePopUp : MonoBehaviour
{
    private TextMeshPro textMesh;
    public float dissappearTimer;
    public float dissappearSpeed;
    public Color enemyHitColor;
    public Color enemyHitCritColor;
    public Color playerHitColor;
    public Color playerHitCritColor;

    private Color textColor;
    public static DamagePopUp Create(Vector3 position, int damage, bool isCriticalHit, string hitTag)
    {
        Transform damagePopUpTransform = Instantiate(GameAssets.i.pfDamagePopUp, position, Quaternion.identity);
        DamagePopUp damagePopUp = damagePopUpTransform.GetComponent<DamagePopUp>();
        damagePopUp.Setup(damage, isCriticalHit, hitTag);

        return damagePopUp;

    }

    private void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
    }

    public void Setup(int damageAmount, bool isCriticalHit, string hitTag)
    {
        textMesh.SetText(damageAmount.ToString());
        if(hitTag == "enemy")
        {
            //Debug.LogWarning("Enemy hit");
            if (!isCriticalHit)
            {

                textColor = enemyHitColor;
            }
            else
            {

                textColor = enemyHitCritColor;
                textMesh.fontSize = textMesh.fontSize + 2;

            }
            textMesh.color = textColor;
        }
        if (hitTag == "player")
        {
            //Debug.LogWarning("Player hit");
            if (!isCriticalHit)
            {

                textColor = playerHitColor;
            }
            else
            {

                textColor = playerHitCritColor;
                textMesh.fontSize = textMesh.fontSize + 2;

            }
            textMesh.color = textColor;
        }


    }
    private void Update()
    {

        transform.position += new Vector3(0, 0.5f, 0) * Time.deltaTime;

        dissappearTimer -= Time.deltaTime;
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
        if( dissappearTimer < 0)
        {
            textColor.a -= dissappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if(textMesh.color.a < 0)
            {
                Destroy(gameObject);
            }
        }

    }
}
