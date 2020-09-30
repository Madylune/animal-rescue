using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    private GameObject floatingText, canvas;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void CreateFloatingText()
    {
        Instantiate(floatingText, canvas.transform).GetComponent<Text>();
    }
}
