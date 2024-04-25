using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterCreator : MonoBehaviour
{
    private CharacterBuilderBase characterBuilderBase;
    private CharacterBuilder characterBuilder;

    public CharacterColorSelector characterColorSelector;

    private void Start()
    {

        characterColorSelector = GetComponent<CharacterColorSelector>();
        characterBuilderBase = new CharacterBuilder()
            .SetHairColor(characterColorSelector.GetCurrentHairColor())
            .SetSkinColor(characterColorSelector.GetCurrentSkinColor())
            .SetEyeColor(characterColorSelector.GetCurrentEyeColor())
            .SetTrousersColor(characterColorSelector.GetCurrentClothingColor());

        characterBuilder = (CharacterBuilder)characterBuilderBase;
        //character = characterBuilder.Build();
        //atvaizduoti default zmogeliuka

    }
    private void Update()
    {
        UpdateAttributes(characterBuilder);
    }
    private void UpdateAttributes(CharacterBuilder characterBuilder)
    {
        characterBuilder.SetHairColor(characterColorSelector.GetCurrentHairColor());
        characterBuilder.SetEyeColor(characterColorSelector.GetCurrentEyeColor());
        characterBuilder.SetSkinColor(characterColorSelector.GetCurrentSkinColor());
        characterBuilder.SetTrousersColor(characterColorSelector.GetCurrentClothingColor());
    }
    public void BuildCharacter()
    {
        Character builtChar = characterBuilderBase.Build();
        Debug.Log("Character built, colors: \n" + builtChar.GetCurrentColors());
        SceneManager.LoadScene("Geimas");
        //return builtChar;

    }
}