using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColorChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterColors colorData;
    public Material eyeMaterial;
    public Material skinMaterial;
    public Material underwearMaterial;
    public Material hairMaterial;
    void Start()
    {
        SetColors();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetColors()
    {
        if (colorData != null)
        {
            eyeMaterial.color = colorData.eyeColor;
            skinMaterial.color = colorData.skinColor;
            underwearMaterial.color = colorData.underwearColor;
            hairMaterial.color = colorData.hairColor;

            Debug.Log("Character colors changed");
        }
        else
            Debug.LogError("Character color data obj is null");

    }
}
