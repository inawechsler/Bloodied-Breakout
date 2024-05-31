using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public PlayerHealth player;
    public Music music;

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

    private void Start()
    {
        string currentLevel = SceneManager.GetActiveScene().name;
        LevelManager.Instance.CurrentLevelName = currentLevel;
    }

    public void PlayerDied()
    {
        SceneManager.LoadScene("LooseScreen");
        Destroy(player.gameObject);
       Destroy(music);
    }
}
