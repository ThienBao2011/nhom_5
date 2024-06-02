using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    Animator ani;
    BoxCollider2D box2d;
    private float gravity;
    private bool isAlive;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    [SerializeField] float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        box2d = GetComponent<BoxCollider2D>();
        gravity = rb.gravityScale;
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Flip();
        Climladder();
        Die();
    }
    
    void OnMove(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }
        moveInput = value.Get<Vector2>();

    }
    void OnJump(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }
        var isTouchingGround = box2d.IsTouchingLayers(LayerMask.GetMask("Ground"));
        if (!isTouchingGround) return;
        if (value.isPressed)
        {
            rb.velocity += new Vector2(0, jumpSpeed);
        }
    }
    void OnFire(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }
        var oneBullet = Instantiate(bullet, gun.position, transform.rotation);
        if (transform.localScale.x < 0)
        {
            oneBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, 0);
        }
        else 
        {
            oneBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);
        }
        Destroy(oneBullet, 2);
    }
    void Run()
    {
        Vector2 moveVelocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
        rb.velocity = moveVelocity;
        bool soSanh = Mathf.Abs(moveInput.x) > Mathf.Epsilon;
        ani.SetBool("isRunning", soSanh);
    }
    void Flip()
    {
        bool soSanh = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (soSanh)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }
    void Climladder()
    {
        var isTouchingLadder = box2d.IsTouchingLayers(LayerMask.GetMask("Climbing"));
        if (!isTouchingLadder)
        {
            rb.gravityScale = gravity;
            ani.SetBool("isClimbing", false);
            return;
        }
        var climbVelocity = new Vector2(rb.velocity.x, moveInput.y * climbSpeed);
        rb.velocity = climbVelocity;
        var animation_climb = Mathf.Abs(moveInput.y) > Mathf.Epsilon;
        ani.SetBool("isClimbing", animation_climb);
        rb.gravityScale = 0;
    }
    void Die()
    {
        var isTouchingEnemy = box2d.IsTouchingLayers(LayerMask.GetMask("Enemy", "Trap"));
        if (isTouchingEnemy)
        {
            isAlive = false;
            ani.SetTrigger("Dying");
            rb.velocity = new Vector2(0, 0);
            // xu ly die
            FindObjectOfType<GameCotroller>().ProcessPlayerDeath();
        }
    }
}
