using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public static BackgroundScroll instance;

    public float scrollSpeed = 0.3f;

    private MeshRenderer meshRenderer;

    private string texture = "_MainTex";

    public bool isScrolling;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        Scroll();
    }

    private void Scroll()
    {
        if (isScrolling)
        {
            Vector2 offset = meshRenderer.sharedMaterial.GetTextureOffset(texture);
            offset.y += Time.deltaTime * scrollSpeed;

            meshRenderer.sharedMaterial.SetTextureOffset(texture, offset);
        }
    }
}
