using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplacePlayerOnFall : MonoBehaviour
{
    public Transform playerRespawn;

    private void Awake()
    {
        playerRespawn = GameObject.FindGameObjectWithTag("PlayerRespawnOF").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerRespawn.position = transform.position;
        }
    }
}
