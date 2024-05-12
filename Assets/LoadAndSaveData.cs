using UnityEngine;

public class LoadAndSaveData : MonoBehaviour
{

    public static LoadAndSaveData instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y'a d�j� plus d'une instance de LoadAndSaveData dans la sc�ne.");
            return;
        }
        instance = this;
    }
    private void Start()
    {
        //Load le nombre de pi�ces
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
        //Les pi�ces du joueur
        PlayerPrefs.SetInt("coinsAmount",Inventory.instance.coinsCount);
        //Niveau atteint
        if(CurrentSceneManager.instance.levelToUnlock > PlayerPrefs.GetInt("levelReached",0))
            PlayerPrefs.SetInt("levelReached",CurrentSceneManager.instance.levelToUnlock);
    }
}
