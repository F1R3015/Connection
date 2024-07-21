using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMusic : MonoBehaviour
{
    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("Speaker").Length == 1)
        {
            DontDestroyOnLoad(this.gameObject);
            Screen.SetResolution(1080, 1920, true);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
