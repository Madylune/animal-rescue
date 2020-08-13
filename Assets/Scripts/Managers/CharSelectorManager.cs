using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelectorManager : MonoBehaviour
{
    public GameObject[] characters;

    [SerializeField]
    private GameObject nextButton;

    [SerializeField]
    private GameObject prevButton;

    private int characterIndex = 0;

    private readonly string selectedCharacter = "SelectedCharacter";

    private void Awake()
    {
        characterIndex = PlayerPrefs.GetInt(selectedCharacter);
        characters[characterIndex].SetActive(true);
    }

    private void Start()
    {
        if (characterIndex < characters.Length)
        {
            nextButton.SetActive(true);
        }
    }

    private void Update()
    {
        if (characterIndex + 1 == characters.Length)
        {
            nextButton.SetActive(false);
        }

        if (characterIndex + 1 < characters.Length)
        {
            nextButton.SetActive(true);
        }

        if (characterIndex < characters.Length && characterIndex != 0)
        {
            prevButton.SetActive(true);
        }

        if (characterIndex == 0)
        {
            prevButton.SetActive(false);
        }

        foreach (GameObject character in characters)
        {
            if (character.name == characters[characterIndex].name)
            {
                characters[characterIndex].SetActive(true);
                PlayerPrefs.SetInt(selectedCharacter, characterIndex);
            }
            else
            {
                character.SetActive(false);
            }
        }
    }

    public void NextCharacter()
    {
        characterIndex++;
    }

    public void PreviousCharacter()
    {
        characterIndex--;
    }
}
