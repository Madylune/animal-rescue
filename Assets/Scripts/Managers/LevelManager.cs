using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    [SerializeField]
    private Text levelNumber;

    public int currentLevel;

    private void Start()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex - 2;
        levelNumber.text = string.Format("LEVEL {0}", sceneIndex);

        currentLevel = sceneIndex;
    }
}
