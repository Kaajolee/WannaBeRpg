using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public Color hairColor;
    public Color skinColor;
    public Color trousersColor;
    public Color eyesColor;

    public Character(Color hairColor, Color eyeColor, Color skinColor, Color clothingColor)
    {
        this.hairColor = hairColor;
        this.skinColor = skinColor;
        trousersColor = clothingColor;
        eyesColor = eyeColor;
    }
    public Character()
    {
        this.hairColor = Color.white;
        this.skinColor = Color.white;
        trousersColor = Color.white;
        eyesColor = Color.white;
    }
    public string GetCurrentColors()
    {
        string colors = $"{hairColor}\n{skinColor}\n{eyesColor}\n{trousersColor}";
        return colors;
    }
    public CharacterColors SetColorData(CharacterColors dataObject)
    {
        dataObject.hairColor = hairColor;
        dataObject.skinColor = skinColor;
        dataObject.eyeColor = eyesColor;
        dataObject.underwearColor = trousersColor;

        return dataObject;
    }
}
