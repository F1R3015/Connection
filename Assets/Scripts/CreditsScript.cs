using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsScript : MonoBehaviour
{

    [SerializeField] GameObject _credits;
    [SerializeField] GameObject _deleteButton;
    public void OpenCredits()
    {
        _credits.SetActive(true);
        _deleteButton.GetComponent<Button>().interactable = false;
    }

    public void CloseCredits()
    {
        _credits.SetActive(false);
        _deleteButton.GetComponent<Button>().interactable = true;
    }
}
