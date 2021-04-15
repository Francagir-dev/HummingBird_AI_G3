using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuButtons : MonoBehaviour
{
    [Header("Canvas")] [SerializeField] private GameObject settingsCanvas;
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject startMenuCanvas;


    public void StartButton()
    {
        startMenuCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);
    }

    public void OpenSettings()
    {
        settingsCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);
    }


    public void DisableSettingsMainMenu()
    {
        settingsCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit(1);
    }

    public void StartGame(int sceneNumber)
    {
        PersistentManager.persistentDataManager.username = GetRandomMatchID();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneNumber);
    }

    public static string GetRandomMatchID()
    {
        string id = string.Empty;
        for (int i = 0; i < 5; i++)
        {
            int random = Random.Range(0, 36);
            if (random < 26)
            {
                id += (char) (random + 65);
            }
            else
            {
                id += (random - 26).ToString();
            }
        }

        Debug.Log("Random username ID:" + id);
        return id;
    }
}