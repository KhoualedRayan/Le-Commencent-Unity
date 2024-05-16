using UnityEngine;

public class ItemsDatabase : MonoBehaviour
{
    public static ItemsDatabase instance;
    public Item[] allItems; 
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y'a déjà plus d'une instance de ItemsDatabase dans la scène.");
            return;
        }
        instance = this;
    }

}
