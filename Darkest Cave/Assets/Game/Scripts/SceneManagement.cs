using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public int levelNumber;

    public static SceneManagement instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerMovement dans la scène");
            return;
        }

        instance = this;
    }


    void Start()
    {
        if (MainMenuScript.instance.ChargedGame == true)
        {
            Inventory.instance.coinsCount = PlayerPrefs.GetInt("Coins");
            Inventory.instance.coinsCountText.text = Inventory.instance.coinsCount.ToString();

            SceneManager.LoadScene(PlayerPrefs.GetInt("LevelNumber"));

            x = GameObject.FindGameObjectWithTag("PlayerSpawn").transform.position.x);
            y = GameObject.FindGameObjectWithTag("PlayerSpawn").transform.position.y);

             = PlayerPrefs.GetFloat("PositionX"
             = PlayerPrefs.GetFloat("PositionY"
        }
    }
}
