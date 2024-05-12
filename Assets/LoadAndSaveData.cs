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
        Inventory.instance.coinsCount = PlayerPrefs.GetInt("coinsAmount",0);
        Inventory.instance.UpdateTextUI();
        PlayerHealth.instance.SetCurrentHealth(PlayerPrefs.GetInt("currentHealth", PlayerHealth.instance.getMaxHealth()));
        

    }
    public void SaveData()
    {
        PlayerPrefs.SetInt("currentHealth",PlayerHealth.instance.getCurrentHealth());
        PlayerPrefs.SetInt("coinsAmount",Inventory.instance.coinsCount);
    }
}
