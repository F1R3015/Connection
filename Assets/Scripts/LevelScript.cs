using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour
{
    [SerializeField] Sprite _star;
    [SerializeField] int _level;
    void Start()
    {
        int _nLevel = PlayerPrefs.GetInt("LevelCompleted",1);
        if(_nLevel >= _level)
        {
            GetComponent<Button>().interactable = true;
        }
        int _nStars = PlayerPrefs.GetInt(this.name,0);
        for(int i = 1; i <= _nStars; i++)
        {
            this.transform.GetChild(i).GetComponent<Image>().sprite = _star;
        }
    }

}
