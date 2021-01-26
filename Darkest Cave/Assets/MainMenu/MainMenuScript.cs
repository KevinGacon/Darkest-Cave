using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject ConfirmTextNewGame;
    public GameObject ConfirmTextContinue;
    public GameObject ConfirmTextQuit;

    public bool ChargedGame = false;

    public static MainMenuScript instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerMovement dans la scène");
            return;
        }

        instance = this;
    }



    public void ConfrimDecisionNewGame()
    {
        ConfirmTextNewGame.SetActive(true);
    }

    public void ConfrimDecisionNewGameYes()
    {
        ChargedGame = false;
        ConfirmTextNewGame.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void ConfrimDecisionNewGameNo()
    {
        ConfirmTextNewGame.SetActive(false);
    }



    public void ConfrimDecisionContinue()
    {
        ConfirmTextContinue.SetActive(true);
    }

    public void ConfrimDecisionContinueYes()
    {
        ChargedGame = true;
        ConfirmTextContinue.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void ConfrimDecisionContinueNo()
    {
        ConfirmTextContinue.SetActive(false);
    }



    public void ConfrimDecisionQuit()
    {
        ConfirmTextQuit.SetActive(true);
    }

    public void ConfrimDecisionQuitYes()
    {
        ConfirmTextQuit.SetActive(false);
        Application.Quit();
    }

    public void ConfrimDecisionQuitNo()
    {
        ConfirmTextQuit.SetActive(false);
    }
}
