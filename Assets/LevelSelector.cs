using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void LoadLevelPasted(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
