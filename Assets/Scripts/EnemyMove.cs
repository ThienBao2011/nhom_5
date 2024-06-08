using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(moveSpeed, 0); 
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("gioi_han"))
        {
            moveSpeed *= -1;
            // xoay
            transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), 1f);
        }
    }
}
