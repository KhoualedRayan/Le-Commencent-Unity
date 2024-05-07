using UnityEngine;
using UnityEngine.SceneManagement;
public class DontDestroyOnLoadScene : MonoBehaviour
{
    public GameObject[] gameObjects;

    public static DontDestroyOnLoadScene instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y'a déjà plus d'une instance de DontDestroyOnLoadScene dans la scène.");
            return;
        }
        instance = this;
        foreach (GameObject go in gameObjects)
        { 
            DontDestroyOnLoad(go);
        }
    }

    public void RemoveFromDontDestoyOnLoad()
    {
        foreach(GameObject go in gameObjects) { 
            SceneManager.MoveGameObjectToScene(go,SceneManager.GetActiveScene());
        }
    }
}
