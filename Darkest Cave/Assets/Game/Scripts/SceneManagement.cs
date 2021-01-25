using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public int checkpointNumber;
    void Start()
    {
        if (MainMenuScript.instance.ChargedGame == true)
        {
            Inventory.instance.coinsCount = PlayerPrefs.GetInt("Coins");
            Inventory.instance.coinsCountText.text = Inventory.instance.coinsCount.ToString();
        }
    }
}
