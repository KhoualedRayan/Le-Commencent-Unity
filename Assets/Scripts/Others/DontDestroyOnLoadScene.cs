using UnityEngine;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    public GameObject[] gameObjects;
    private void Awake()
    {
        foreach (GameObject go in gameObjects)
        { 
            DontDestroyOnLoad(go);
        }
    }
}
