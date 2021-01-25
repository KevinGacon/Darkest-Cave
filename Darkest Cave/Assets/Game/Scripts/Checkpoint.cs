using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Transform playerSpawn;
    public Animator animator;

    public new Light light;

    public int levelNumber;

    public static Checkpoint instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerMovement dans la scène");
            return;
        }

        instance = this;

        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerSpawn.position = transform.position;

            PlayerHealth.instance.currentHealth = PlayerHealth.instance.maxHealth;
            PlayerHealth.instance.healthbar.SetHealth(PlayerHealth.instance.currentHealth);
            PlayerMana.instance.currentMana = PlayerMana.instance.maxMana;
            PlayerMana.instance.currentManaDisplay.text = PlayerMana.instance.currentMana.ToString();

            animator.SetTrigger("TurnOn");
            light.enabled = true;

            SaveData();
        }
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("Coins", Inventory.instance.coinsCount);

        PlayerPrefs.SetFloat("PositionX", playerSpawn.position.x);
        PlayerPrefs.SetFloat("PositionY", playerSpawn.position.y);
    }
}
