using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarInLevel : MonoBehaviour
{

    [SerializeField] GameObject _star;
    [SerializeField] Sprite _sprite;
    
    // Update is called once per frame
    void Update()
    {
        if (!_star.activeSelf)
        {
            GetComponent<Image>().sprite = _sprite;
            Destroy(this);
        }   
    }
}
