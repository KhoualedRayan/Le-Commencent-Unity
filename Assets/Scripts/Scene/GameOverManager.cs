using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public static GameOverManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y'a d�j� plus d'une instance de GameOverManager dans la sc�ne.");
            return;
        }
        instance = this;
    }
    public void OnPlayerDeath()
    {
        if (CurrentSceneManager.instance.isPlayerPresentByDefault)
        {
            DontDestroyOnLoadScene.instance.RemoveFromDontDestoyOnLoad();
        }
        gameOverUI.SetActive(true);
    }
    public void RetryButton()
    {
        //Recommencer le niveau
        //Recharge la sc�ne && Replace le perso au spawn
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //R�active les mouvements du joueur + qu'on lui rende sa vie
        PlayerHealth.instance.Respawn();
        //Enl�ve les pi�ces r�cuperer dans le niveau
        Inventory.instance.RemoveCoins(CurrentSceneManager.instance.GetCoinsPickedInThisScene());
        //D�sactive le menu de GameOver
        gameOverUI.SetActive(false);
    }
    public void MainMenuButton()
    {
        //Retour au menu principal
    }
    public void QuitMenu()
    {
        //Fermer le jeu
        Application.Quit();
    }
}
