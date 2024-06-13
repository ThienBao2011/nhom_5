using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BossSlime : MonoBehaviour
{
    public int health = 5;
    public TilemapManager tilemapManager;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (tilemapManager != null)
        {
            tilemapManager.DestroyTilemap();
        }
        Destroy(gameObject);
    }
}
