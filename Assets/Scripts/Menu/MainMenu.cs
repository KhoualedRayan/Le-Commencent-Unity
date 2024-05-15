using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "Level01";
    public GameObject settingsWindow;
    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(levelToLoad);
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }
    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }
    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
