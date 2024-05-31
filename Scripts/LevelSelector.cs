using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private Button Level1;
    [SerializeField] private Button Level2;
    [SerializeField] private Button Level3;
    [SerializeField] private Button Level4;
    [SerializeField] private Button Level5;
    [SerializeField] private Button MainMenu;

    public void Awake()
    {
        Level1.onClick.AddListener(Intro);
        Level2.onClick.AddListener(LevelOne);
        Level3.onClick.AddListener(LevelTwo);
        Level4.onClick.AddListener(LevelThree);
        Level5.onClick.AddListener(LevelFour);
        MainMenu.onClick.AddListener(Menu);
    }

    public void Intro()
    {
        SceneManager.LoadScene("Level Intro");
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LevelOne()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void LevelTwo()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void LevelThree()
    {
        SceneManager.LoadScene("Level 3");
    }
    public void LevelFour()
    {
        SceneManager.LoadScene("Level 4");
    }
}
