using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public bool isPlayerPresentByDefault = false;
    private int coinsPickedInThisScene;

    public static CurrentSceneManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y'a d�j� plus d'une instance de CurrentSceneManager dans la sc�ne.");
            return;
        }
        instance = this;
    }
    public void AddCoinInScene(int coin)
    {
        coinsPickedInThisScene += coin;
    }
    public int GetCoinsPickedInThisScene()
    {
        return coinsPickedInThisScene;
    }

}
