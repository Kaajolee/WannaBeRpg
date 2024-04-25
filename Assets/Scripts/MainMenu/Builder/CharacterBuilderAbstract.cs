using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBuilderBase : MonoBehaviour
{
    protected Character character;
    public Character Character { get { return character; } }

    public abstract CharacterBuilderBase SetEyeColor(Color eyeColor);
    public abstract CharacterBuilderBase SetSkinColor(Color skinColor);
    public abstract CharacterBuilderBase SetHairColor(Color hairColor);
    public abstract CharacterBuilderBase SetTrousersColor(Color trousersColor);

    public abstract Character Build();
}
