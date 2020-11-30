using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform rightAttackPoint;
    public Transform leftAttackPoint;
    public Transform upAttackPoint;
    public Transform downAttackPoint;
    public float attackRange = 13f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;

    public float attackRate = 2f;
    private float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                AttackRight();
                nextAttackTime = Time.time + 1f / attackRate;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                AttackLeft();
                nextAttackTime = Time.time + 1f / attackRate;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                AttackUp();
                nextAttackTime = Time.time + 1f / attackRate;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (PlayerMovement.instance.isGrounded == false)
                {
                    AttackDown();
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }
        }
    }

    void AttackRight()
    {
        // Detect enemies in the attack's direction
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(rightAttackPoint.position, attackRange, enemyLayers);  

        // Damage enemies
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.name + " has been hit !");

            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }

    void AttackLeft()
    {
        // Detect enemies in the attack's direction        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(leftAttackPoint.position, attackRange, enemyLayers);

        // Damage enemies
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.name + " has been hit !");

            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }

    void AttackUp()
    {
        // Detect enemies in the attack's direction      
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(upAttackPoint.position, attackRange, enemyLayers);

        // Damage enemies
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.name + " has been hit !");

            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }

    void AttackDown()
    {
        // Detect enemies in the attack's direction
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(downAttackPoint.position, attackRange, enemyLayers);

        // Damage enemies
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.name + " has been hit !");

            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (rightAttackPoint == null) return;
        Gizmos.DrawWireSphere(rightAttackPoint.position, attackRange);
        if (leftAttackPoint == null) return;
        Gizmos.DrawWireSphere(leftAttackPoint.position, attackRange);
        if (upAttackPoint == null) return;
        Gizmos.DrawWireSphere(upAttackPoint.position, attackRange);
        if (downAttackPoint == null) return;
        Gizmos.DrawWireSphere(downAttackPoint.position, attackRange);
    }
}
