using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _selectLevel;

    public void StartGame()
    {
        _mainMenu.SetActive(false);
        _selectLevel.SetActive(true);
    }

    public void GoBack()
    {
        _mainMenu.SetActive(true);
        _selectLevel.SetActive(false);
    }

    public void SelectLevel(string LevelName)
    {
        SceneManager.LoadScene(LevelName);
    }
}
