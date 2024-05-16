using UnityEngine;

public class ItemsDatabase : MonoBehaviour
{
    public static ItemsDatabase instance;
    public Item[] allItems; 
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y'a d�j� plus d'une instance de ItemsDatabase dans la sc�ne.");
            return;
        }
        instance = this;
    }

}
