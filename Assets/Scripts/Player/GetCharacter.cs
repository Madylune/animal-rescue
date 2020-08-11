using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCharacter : MonoBehaviour
{
    private readonly string selectedCharacter = "SelectedCharacter";

    private void Start()
    {
        int characterIndex;

        characterIndex = PlayerPrefs.GetInt(selectedCharacter);

        GameObject character;

        character = transform.GetChild(characterIndex).gameObject;

        character.SetActive(true);
    }
}
