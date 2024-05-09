using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool gameIsPaused = false;
    public GameObject settingsMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused) {
                Resume();
            }
            else
            {
                Paused();
            }
        }        
    }
    private void Paused()
    {
        PlayerMovement.instance.enabled = false;
        //Activer notre menu pause / l'afficher
        pauseMenuUI.SetActive(true);
        //Arrêter le temps
        Time.timeScale = 0;  
        //Changer le statut du jeu
        gameIsPaused = true;
    }
    public void Resume()
    {
        //L'inverse
        PlayerMovement.instance.enabled=true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
        settingsMenuUI.SetActive(false);
    }
    public void LoadMainMenu()
    {
        DontDestroyOnLoadScene.instance.RemoveFromDontDestoyOnLoad();
        Resume();
        SceneManager.LoadScene("MainMenu");
        
    }
    public void OpenSettingsButton()
    {
        settingsMenuUI.SetActive(true);
    }
    public void CloseSettingsButton()
    {
        settingsMenuUI.SetActive(false);
    }
}
