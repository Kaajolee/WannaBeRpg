using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColorSelector : MonoBehaviour
{
    // Start is called before the first frame update
    Color[] hairColorArray = { Color.white, Color.black, Color.cyan };
    Color[] eyeColorArray = {Color.white, Color.red, Color.blue };
    Color[] skinColorArray = {Color.gray, Color.green, Color.blue };
    Color[] clothingColorArray = { Color.yellow, Color.blue, Color.black };

    public Material hairMat;
    public Material eyeMat;
    public Material skinMat;
    public Material clothingMat;

    public int hairIndex, eyeIndex, skinIndex, clothingIndex;

    AudioSource audioSource;
    void Start()
    {
        hairIndex = eyeIndex = skinIndex = clothingIndex = 0;
        audioSource = Camera.main.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateColors();
    }
    void UpdateColors()
    {
        hairMat.color = hairColorArray[hairIndex];
        eyeMat.color = eyeColorArray[eyeIndex];
        skinMat.color = skinColorArray[skinIndex];
        clothingMat.color = clothingColorArray[clothingIndex];
    }
    public void ShiftHairLeft()
    {
        if (hairIndex == 0)
            return;
        else
            hairIndex--;

        audioSource.Play();
    }
    public void ShiftHairRight()
    {
        if (hairIndex == hairColorArray.Length-1)
            return;
        else
            hairIndex++;

        audioSource.Play();
    }
    public void ShiftEyeLeft()
    {
        if (eyeIndex == 0)
            return;
        else
            eyeIndex--;

        audioSource.Play();
    }
    public void ShiftEyeRight()
    {
        if (eyeIndex == eyeColorArray.Length - 1)
            return;
        else
            eyeIndex++;

        audioSource.Play();
    }
    public void ShiftSkinLeft()
    {
        if (skinIndex == 0)
            return;
        else
            skinIndex--;

        audioSource.Play();
    }
    public void ShiftSkinRight()
    {
        if (skinIndex == skinColorArray.Length - 1)
            return;
        else
            skinIndex++;

        audioSource.Play();
    }
    public void ShiftClothingLeft()
    {
        if (clothingIndex == 0)
            return;
        else
            clothingIndex--;

        audioSource.Play();
    }
    public void ShiftClothingRight()
    {
        if (clothingIndex == clothingColorArray.Length - 1)
            return;
        else
            clothingIndex++;

        audioSource.Play();
    }
    public Color GetCurrentHairColor()
    {
        return hairColorArray[hairIndex];
    }
    public Color GetCurrentEyeColor()
    {
        return eyeColorArray[eyeIndex];
    }
    public Color GetCurrentSkinColor()
    {
        return skinColorArray[skinIndex];
    }
    public Color GetCurrentClothingColor()
    {
        return clothingColorArray[clothingIndex];
    }
    public Material GetHairMaterial()
    {
        return hairMat;
    }
    public Material GetEyeMaterial()
    {
        return eyeMat;
    }
    public Material GetSkinMaterial()
    {
        return skinMat;
    }
    public Material GetClothingMaterial()
    {
        return clothingMat;
    }
    public void SetColors()
    {
        Debug.Log("hair color: " + hairColorArray[hairIndex]+"\n" +
                          "eye color: " + eyeColorArray[eyeIndex] + "\n" +
                          "skin color: " + skinColorArray[skinIndex] + "\n" +
                          "clothing color: " + clothingColorArray[clothingIndex]);
    }
}
