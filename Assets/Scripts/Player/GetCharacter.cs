using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCharacter : MonoBehaviour
{
    private readonly string selectedCharacter = "SelectedCharacter";

    [SerializeField]
    private Text jumpButton;

    private void Start()
    {
        int characterIndex;

        characterIndex = PlayerPrefs.GetInt(selectedCharacter);

        GameObject character;

        character = transform.GetChild(characterIndex).gameObject;

        character.SetActive(true);

        if (characterIndex == 0)
        {
            jumpButton.text = "FLY";
        }
        if (characterIndex == 1)
        {
            jumpButton.text = "JUMP";
        }
    }
}
