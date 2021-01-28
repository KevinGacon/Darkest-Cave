using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour
{
    private Transform playerRespawn;
    public Animator fadeSystem;

    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
        playerRespawn = GameObject.FindGameObjectWithTag("PlayerRespawnOF").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ReplacePlayer(collision));
        }
    }

    public IEnumerator ReplacePlayer(Collider2D collision)
    {
        PlayerHealth.instance.currentHealth = PlayerHealth.instance.currentHealth - 2;
        PlayerHealth.instance.healthbar.SetHealth(PlayerHealth.instance.currentHealth);

        if (PlayerHealth.instance.currentHealth <= 0)
        {
            PlayerDeath.instance.Death();
        }
        else
        {
            fadeSystem.SetTrigger("FadeIN");
            yield return new WaitForSeconds(0.8f);

            if (Inventory.instance.coinsCount > 0)
            {
                Inventory.instance.coinsCount = Inventory.instance.coinsCount / 2;
                Inventory.instance.coinsCountText.text = Inventory.instance.coinsCount.ToString();
            }

            collision.transform.position = playerRespawn.position;
        }
    }
}
