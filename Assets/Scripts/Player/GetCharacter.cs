using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCharacter : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;

    private SpriteRenderer spriteRenderer;

    private readonly string selectedCharacter = "SelectedCharacter";

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        int characterIndex;

        characterIndex = PlayerPrefs.GetInt(selectedCharacter);

        spriteRenderer.sprite = sprites[characterIndex];
    }
}
