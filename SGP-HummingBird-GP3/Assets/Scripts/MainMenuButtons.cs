using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject settingsCanvas;
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private bool settingsIsActive = false;

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenSettings()
    {
        Debug.Log(settingsIsActive);
        if (!settingsIsActive)
        {
            settingsCanvas.SetActive(true);
            mainMenuCanvas.SetActive(false);
            settingsIsActive = true;
        }
        else
        {
            settingsCanvas.SetActive(false);
            mainMenuCanvas.SetActive(true);
            settingsIsActive = false;
        }
    }

    public void QuitGame()
    {
        Application.Quit(1);
    }
}