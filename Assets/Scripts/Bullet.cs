using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
<<<<<<< HEAD:Assets/Scene4/Scripts/Bullet.cs
    [SerializeField] float damage = 1f;
=======
>>>>>>> main:Assets/Scripts/Bullet.cs
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
<<<<<<< HEAD:Assets/Scene4/Scripts/Bullet.cs
    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.takeDamage(damage);
=======

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            
>>>>>>> main:Assets/Scripts/Bullet.cs
        }
        Destroy(gameObject);
    }
}
