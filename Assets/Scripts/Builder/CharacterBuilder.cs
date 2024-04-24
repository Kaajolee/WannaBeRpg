using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBuilderBase
{
    protected Character character;
    public Character Character { get { return character; } }

    public abstract CharacterBuilderBase SetEyeColor(Color eyeColor);
    public abstract CharacterBuilderBase SetSkinColor(Color skinColor);
    public abstract CharacterBuilderBase SetHairColor(Color hairColor);
    public abstract CharacterBuilderBase SetTrousersColor(Color trousersColor);

    public abstract Character Build();
}
public class CharacterBuilder : CharacterBuilderBase
{
    public CharacterBuilder()
    {
        character = new Character();
    }
    public override CharacterBuilderBase SetEyeColor(Color eyeColor)
    {
        character.eyesMaterial.color = eyeColor;
        return this;
    }
    public override CharacterBuilderBase SetSkinColor(Color skinColor)
    {
        character.eyesMaterial.color = skinColor;
        return this;
    }
    public override CharacterBuilderBase SetHairColor(Color hairColor)
    {
        character.eyesMaterial.color = hairColor;
        return this;
    }
    public override CharacterBuilderBase SetTrousersColor(Color trousersColor)
    {
        character.eyesMaterial.color = trousersColor;
        return this;
    }
    public override Character Build()
    {
        return character;
    }
}
public class Character
{
    public Material hairMaterial;
    public Material skinMaterial;
    public Material trousersMaterial;
    public Material eyesMaterial;

    public Character()
    {
        eyesMaterial.color = Color.white;
        skinMaterial.color = Color.white;
        hairMaterial.color = Color.white;
        trousersMaterial.color = Color.white;
    }
}
public class CharacterCreator : MonoBehaviour
{
    private CharacterBuilderBase characterBuilder;

    public Material hairMaterial;
    public Material skinMaterial;
    public Material trousersMaterial;
    public Material eyesMaterial;

    private void Start()
    {


        characterBuilder = new CharacterBuilder()
            .SetHairColor(hairMaterial.color)
            .SetSkinColor(skinMaterial.color)
            .SetEyeColor(eyesMaterial.color)
            .SetTrousersColor(trousersMaterial.color);

        Character character = characterBuilder.Build();
        ChangeAttribute(character);
        //atvaizduoti default zmogeliuka

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //pakeisti plauku spalva i betkokia paspaudus space

        }
    }
    private void ChangeAttribute(Character character)
    {
        character.hairMaterial.color = Random.ColorHSV();
    }
}
