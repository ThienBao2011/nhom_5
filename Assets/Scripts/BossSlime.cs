using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSlime : MonoBehaviour
{
    public float fireRate = 2f; // Tốc độ bắn đạn
    public GameObject bulletPrefab; // Prefab của đạn
    public float bulletSpeed = 5f; // Tốc độ của đạn
    public float bulletLifetime = 2f; // Thời gian sống của đạn
    public int maxHealth = 100; // Máu tối đa của boss

    private int currentHealth; // Máu hiện tại của boss
    private Rigidbody2D rb;
    private bool isFiring = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth; // Thiết lập máu ban đầu
        StartCoroutine(FireBullets());
    }
    IEnumerator FireBullets()
    {
        while (true)
        {
            // Tạo đạn bắn ra từ nhiều hướng
            int numberOfBullets = 8; // Số lượng đạn
            float angleStep = 360f / numberOfBullets;

            for (int i = 0; i < numberOfBullets; i++)
            {
                float angle = i * angleStep;
                float bulletDirX = Mathf.Cos(angle * Mathf.Deg2Rad);
                float bulletDirY = Mathf.Sin(angle * Mathf.Deg2Rad);
                Vector3 bulletDirection = new Vector3(bulletDirX, bulletDirY, 0).normalized;

                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed;
                Destroy(bullet, bulletLifetime); // Hủy đạn sau thời gian sống
            }

            yield return new WaitForSeconds(fireRate);
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
