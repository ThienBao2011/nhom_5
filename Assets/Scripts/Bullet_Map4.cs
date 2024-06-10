using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Map4 : MonoBehaviour
{
    public int damage = 10; // Sát thương của đạn
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BossSlime boss = collision.GetComponent<BossSlime>();
        if (boss != null)
        {
            boss.TakeDamage(damage);
            Destroy(gameObject); 
        }
    }
}
