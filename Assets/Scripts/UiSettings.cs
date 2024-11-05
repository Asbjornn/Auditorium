using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiSettings : MonoBehaviour
{
    public static int indexLevel = 0;

    public TextMeshProUGUI text;
    public GameObject menu;
    public GameObject pausePannel;
    public GameData gameData;
    bool isOpen = false;

    private void Start()
    {
        if(GetActualScene() == "Menu")
        {
            gameData.currentLevelIndex = 0;
            UiSettings.indexLevel = 0;
            menu.SetActive(true);
        }
        else
        {
            //text.text = "Level : " + gameData.levels[gameData.currentLevelIndex].levelNumber.ToString();
            text.text = "Level : " + gameData.levels[UiSettings.indexLevel].levelNumber.ToString();
            menu.SetActive(false);
        }

        if(Time.timeScale < 1f)
        {
            Time.timeScale = 1f;
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isOpen)
            {
                Time.timeScale = 0f;
                pausePannel.SetActive(true);
                isOpen = true;
            }
            else
            {
                Time.timeScale = 1f;
                pausePannel.SetActive(false);
                isOpen = false;
            }
        }
    }

    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void OpenGameObject(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    public void CloseGameObject(GameObject gameObject)
    {
        if(Time.timeScale < 1f)
        {
            Time.timeScale = 1f;
        }
        gameObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public string GetActualScene()
    {
        return SceneManager.GetActiveScene().name;
    }
}


// Scriptable object qui prend la victoire
//récupère l'info dans la scene UI
//avec un event
//Scriptable Object