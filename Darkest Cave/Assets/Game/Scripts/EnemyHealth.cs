using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public GameObject Enemy;

    public SpriteRenderer graphics;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // TakeDamage is called when the player hits the enemy
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        StartCoroutine(HitAnimation());

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died !");

        Destroy(Enemy);
    }

    public IEnumerator HitAnimation()
    {
        graphics.color = new Color(1f, 0f, 0f, 1f);
        yield return new WaitForSeconds(0.3f);
        graphics.color = new Color(1f, 1f, 1f, 1f);
    }
}