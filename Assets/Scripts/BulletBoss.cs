using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoss : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 10;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BossSlime boss = collision.GetComponent<BossSlime>();
        if (boss != null)
        {
            boss.TakeDamage(damage);
        }
        Destroy(gameObject); 
    }
}
