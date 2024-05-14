using UnityEngine;

public class LoadAndSaveData : MonoBehaviour
{

    public static LoadAndSaveData instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y'a déjà plus d'une instance de LoadAndSaveData dans la scène.");
            return;
        }
        instance = this;
    }
    private void Start()
    {
        //Load le nombre de pièces
        Inventory.instance.coinsCount = PlayerPrefs.GetInt("coinsAmount",0);
        Inventory.instance.UpdateTextUI();
        //La vie du joueur
        PlayerHealth.instance.SetCurrentHealth(PlayerPrefs.GetInt("currentHealth", PlayerHealth.instance.getMaxHealth()));
        //

    }
    public void SaveData()
    {
        //Save la vie du joueur
        PlayerPrefs.SetInt("currentHealth",PlayerHealth.instance.getCurrentHealth());
        //Les pièces du joueur
        PlayerPrefs.SetInt("coinsAmount",Inventory.instance.coinsCount);
        //Niveau atteint
        if(CurrentSceneManager.instance.levelToUnlock > PlayerPrefs.GetInt("levelReached",0))
            PlayerPrefs.SetInt("levelReached",CurrentSceneManager.instance.levelToUnlock);
    }
}
