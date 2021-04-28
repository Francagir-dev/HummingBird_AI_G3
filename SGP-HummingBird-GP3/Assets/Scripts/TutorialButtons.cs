using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialButtons : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene("Scenes/MenuScene");
    }

    public void GoToHospital()
    {
        SceneManager.LoadScene("Scenes/HospitalRoom");
    }
}