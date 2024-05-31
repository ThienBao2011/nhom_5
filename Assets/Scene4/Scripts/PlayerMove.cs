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
    Animator ani;
    BoxCollider2D box2d;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        box2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Flip();
    }
    
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

    }
    void OnJump(InputValue value)
    {
        var isTouchingGround = box2d.IsTouchingLayers(LayerMask.GetMask("Ground"));
        if (!isTouchingGround) return;
        if (value.isPressed)
        {
            rb.velocity += new Vector2(0, jumpSpeed);
        }
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
}
