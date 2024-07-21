using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeleteData : MonoBehaviour
{
    public void DeleteTheData()
    {
        PlayerPrefs.SetInt("LevelCompleted", 1);
        for(int i = 1; i<=9; i++)
        {
            PlayerPrefs.SetInt("Level" + i, 0);
        }
        SceneManager.LoadScene("MainMenu");
    }
}
