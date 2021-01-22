using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject SelectMenu;
    public GameObject Commands;

    public GameObject ConfirmTextQuit;
    public GameObject ConfirmTextMainMenu;

    public GameObject DontDestroyOnloadObject;


    private void Start()
    {
        SelectMenu.SetActive(false);
        Commands.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        SelectMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        SelectMenu.SetActive(false);
        Commands.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Command()
    {
        Commands.SetActive(true);
        SelectMenu.SetActive(false);
    }

    public void MainMenu()
    {
        ConfirmTextMainMenu.SetActive(true);
    }
    public void ConfrimDecisionMainMenuYes()
    {
        Destroy(DontDestroyOnloadObject);
        SceneManager.LoadScene("MainMenu");
        Resume();
        ConfirmTextMainMenu.SetActive(false);
    }

    public void ConfrimDecisionMainMenuNo()
    {
        ConfirmTextMainMenu.SetActive(false);
    }


    public void Quit()
    {
        ConfirmTextQuit.SetActive(true);
    }

    public void ConfrimDecisionQuitYes()
    {
        Application.Quit();
    }

    public void ConfrimDecisionQuitNo()
    {
        ConfirmTextQuit.SetActive(false);
    }
}
