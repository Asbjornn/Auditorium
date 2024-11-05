using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject settings;
    bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Settings", LoadSceneMode.Additive);
        settings = GameObject.Find("Settings");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOpen)
            {
                Time.timeScale = 0f;
                settings.SetActive(true);
                isOpen = false;
            }
            else
            {
                Time.timeScale = 1f;
                settings.SetActive(false);
                isOpen = true;
            }
        }
    }

    public void PauseMode()
    {

    }
}
