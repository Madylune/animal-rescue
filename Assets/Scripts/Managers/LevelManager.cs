using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Text levelNumber;

    private void Start()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        levelNumber.text = string.Format("LEVEL {0}", sceneIndex);
    }
}
