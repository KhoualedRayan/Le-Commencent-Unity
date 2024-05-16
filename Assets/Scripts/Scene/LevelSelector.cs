using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button[] levelButtons;
    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached",1);
        for(int i = 0; i < levelReached; i++)
        {
            levelButtons[i].interactable = true;
        }
    }
    public void LoadLevelPasted(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
