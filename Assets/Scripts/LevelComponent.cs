using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelComponent : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image levelIcon;
    public Button button;
    public GameData gameData;
    public LevelData actualLevelData;


    public void Initialize(LevelData data)
    {
        text.text = data.levelName;
        levelIcon.sprite = data.icon;

        if(!data.unlock)
        {
            button.interactable = false;
        }

        button.onClick.AddListener(delegate
        {
            //gameData.LoadNextLevel();
            SceneManager.LoadScene(actualLevelData.levelName);
            //gameData.currentLevelIndex = actualLevelData.id;
            UiSettings.indexLevel = actualLevelData.id;
        });
        
        /*button.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(data.sceneName);
        });*/

    }
}
