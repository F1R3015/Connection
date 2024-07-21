using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    [SerializeField] GameObject _ball;
    [SerializeField] GameObject _startUI;
    public void StartTheLevel()
    {
        Destroy(GetComponent<CreateRope>());
        _startUI.SetActive(false);
        _ball.SetActive(true);
    }
}
