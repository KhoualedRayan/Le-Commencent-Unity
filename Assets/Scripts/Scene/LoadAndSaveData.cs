using System.Linq;
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
        //Chargement des items
        string[] itemsSaved = PlayerPrefs.GetString("items", "").Split(',',System.StringSplitOptions.RemoveEmptyEntries);
        foreach (string item in itemsSaved)
        {
            int id = int.Parse(item);
            Item currentItem = ItemsDatabase.instance.allItems.Single(x => x.id == id);
            Inventory.instance.content.Add(currentItem);
            Debug.Log("Item chargé : " + item);
        }
        Inventory.instance.UpdateInventoryUI();

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

        //Sauvegarde des items
        string itemsInInventory = string.Join(",",Inventory.instance.content.Select(x => x.id));
        PlayerPrefs.SetString("items",itemsInInventory);
        Debug.Log("Les items sauvegardés sont : " + itemsInInventory);

    }
}
