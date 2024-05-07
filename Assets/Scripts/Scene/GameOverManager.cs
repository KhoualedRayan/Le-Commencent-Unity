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
            Debug.LogWarning("Il y'a déjà plus d'une instance de GameOverManager dans la scène.");
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
        //Recharge la scène && Replace le perso au spawn
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Réactive les mouvements du joueur + qu'on lui rende sa vie
        PlayerHealth.instance.Respawn();
        //Enlève les pièces récuperer dans le niveau
        Inventory.instance.RemoveCoins(CurrentSceneManager.instance.GetCoinsPickedInThisScene());
        //Désactive le menu de GameOver
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
