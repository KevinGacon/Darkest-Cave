using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public int levelNumber;

    public Transform player;
    public Transform playerSpawn;

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

        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;

        Vector2 position = new Vector2(PlayerPrefs.GetFloat("PositionX"), PlayerPrefs.GetFloat("PositionY"));

        if (MainMenuScript.instance.ChargedGame == true)
        {
            Inventory.instance.coinsCount = PlayerPrefs.GetInt("Coins");
            Inventory.instance.coinsCountText.text = Inventory.instance.coinsCount.ToString();

            SceneManager.LoadScene(PlayerPrefs.GetInt("LevelNumber"));

            player.position = position;
            playerSpawn.position = position;
        }
    }
}
