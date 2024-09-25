using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour
{
    [SerializeField] string _nextLevel;
    public void NextLevel()
    {
        SceneManager.LoadScene(_nextLevel);
    }
}
