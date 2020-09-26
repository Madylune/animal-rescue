using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance;

    [SerializeField]
    private GameObject[] popUps;

    [SerializeField]
    private GameObject actionBar, star, jumpInfos, flag, pauseButton;

    private int popUpIndex = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        if (Application.platform != RuntimePlatform.IPhonePlayer)
        {
            actionBar.SetActive(false);
        }
        pauseButton.SetActive(false);
    }

    private void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }

        if (popUpIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 1)
        {
            if (star)
            {
                star.SetActive(true);
                jumpInfos.SetActive(true);
            }
            else
            {
                popUpIndex++;
                jumpInfos.SetActive(false);
            }
        }
        else if (popUpIndex == 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 3)
        {
            flag.SetActive(true);
        }
    }
}
