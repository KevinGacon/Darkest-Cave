using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    void start()
    {
        Inventory.instance.coinsCount = PlayerPrefs.GetInt("Coins");
        Inventory.instance.coinsCountText.text = Inventory.instance.coinsCount.ToString();
    }
}
