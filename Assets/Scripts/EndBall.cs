using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBall : MonoBehaviour
{
    private int nStars = 0;
    [SerializeField] GameObject _starsUI;
    [SerializeField] GameObject _gameOverUI;
    [SerializeField] GameObject _homeUI;
    [SerializeField] GameObject _reloadUI;
    [SerializeField] string _levelName;
    [SerializeField] int _levelID;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EndHole"))
        {
            collision.GetComponent<AudioSource>().Play();
            if (nStars > PlayerPrefs.GetInt(_levelName, 0))
            {
                PlayerPrefs.SetInt(_levelName, nStars);
            }
            if(_levelID == PlayerPrefs.GetInt("LevelCompleted", 1))
            {
                PlayerPrefs.SetInt("LevelCompleted", _levelID+1);
            }

            _starsUI.GetComponent<RectTransform>().localPosition = new Vector2(0,-687);
            _gameOverUI.SetActive(true);
            _homeUI.GetComponent<RectTransform>().localPosition = new Vector2(-181, -65);
            _reloadUI.GetComponent<RectTransform>().localPosition = new Vector2(178, -65);
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Star"))
        {
            collision.transform.gameObject.SetActive(false);
            nStars++;
            _starsUI.GetComponent<AudioSource>().Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();
    }
}
