using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{

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
        gameObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
