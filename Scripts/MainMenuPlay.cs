using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuPlay : MonoBehaviour
{

    [SerializeField] private Button playGame;
    [SerializeField] private Button exitGame;
    [SerializeField] private Button levelSelector;
    [SerializeField] private string introLevel;
    // Start is called before the first frame update
    void Awake()
    {
        playGame.onClick.AddListener(PlayGame);
        exitGame.onClick.AddListener(ExitGame);
        levelSelector.onClick.AddListener(Level);
    }


    void PlayGame()
    {
        SceneManager.LoadScene(introLevel);
    }

    void Level()
    {
        SceneManager.LoadScene("Level Selector");
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
