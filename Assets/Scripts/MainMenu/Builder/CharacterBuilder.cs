using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBuilder : CharacterBuilderBase
{
    public CharacterBuilder()
    {
        character = new Character();
    }
    public override CharacterBuilderBase SetEyeColor(Color eyeColor)
    {
        character.eyesColor = eyeColor;
        return this;
    }
    public override CharacterBuilderBase SetSkinColor(Color skinColor)
    {
        character.skinColor = skinColor;
        return this;
    }
    public override CharacterBuilderBase SetHairColor(Color hairColor)
    {
        character.hairColor = hairColor;
        return this;
    }
    public override CharacterBuilderBase SetTrousersColor(Color trousersColor)
    {
        character.trousersColor = trousersColor;
        return this;
    }
    public override Character Build()
    {
        return character;
    }
}


