using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "new GameData", menuName = "Game/Data")]
public class GameData : ScriptableObject
{
    public int currentLevelIndex = 0;
    public List<LevelData> levels;

    public void LoadNextLevel()
    {
        currentLevelIndex++;
        UiSettings.indexLevel++;
        if (UiSettings.indexLevel >= levels.Count)
        {
            SceneManager.LoadScene("Menu");
        }
        else
        {
            SceneManager.LoadScene(levels[UiSettings.indexLevel].sceneName);
            levels[UiSettings.indexLevel].unlock = true;
        }
        /*if (currentLevelIndex >= levels.Count)
        {            
            SceneManager.LoadScene("Menu");  
        }
        else
        {
            SceneManager.LoadScene(levels[currentLevelIndex].sceneName);
            levels[currentLevelIndex].unlock = true;
        }*/
        //currentLevelIndex = levels[currentLevelIndex].id +1;
    }
}
