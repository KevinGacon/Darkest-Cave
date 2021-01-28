using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    private void Awake()
    {
        Vector2 position = new Vector2(PlayerPrefs.GetFloat("PositionX"), PlayerPrefs.GetFloat("PositionY"));

        if (MainMenuScript.instance.ChargedGame == true)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = position;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
        }

        GameObject.FindGameObjectWithTag("MainCamera").transform.position = transform.position;
    }
}
