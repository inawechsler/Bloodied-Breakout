using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    public string CurrentLevelName { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadLevel(string levelName)
    {
        CurrentLevelName = levelName;
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
    }

    public void ReloadCurrentLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(CurrentLevelName);
    }
}

