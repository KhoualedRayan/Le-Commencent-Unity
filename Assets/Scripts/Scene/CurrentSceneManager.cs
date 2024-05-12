using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    private int coinsPickedInThisScene;
    private Vector3 respawnPoint;

    public static CurrentSceneManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y'a d�j� plus d'une instance de CurrentSceneManager dans la sc�ne.");
            return;
        }
        instance = this;
        respawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
    public void AddCoinInScene(int coin)
    {
        coinsPickedInThisScene += coin;
    }
    public int GetCoinsPickedInThisScene()
    {
        return coinsPickedInThisScene;
    }

    public Vector3 GetRespawnPoint()
    {
        return respawnPoint;
    }
    public void SetRespawnPoint(Vector3 vector3)
    {
        respawnPoint = vector3;
    }
}
