using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DefeatScreen : MonoBehaviour
{
    [SerializeField] private Button RetryButton;
    [SerializeField] private Button MainMenuButton;
    public void Awake()
    {
        RetryButton.onClick.AddListener(Retry);
        MainMenuButton.onClick.AddListener(MainMenu);
    }
    public void Retry()
    {
        LevelManager.Instance.ReloadCurrentLevel();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
