using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;
    [SerializeField] float moveSpeed = 5f;
    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
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
    void OnJump()
    {

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
