using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    private Rigidbody2D _rigidbody2D;
    Vector2 moveInput;
    private Animator _animator;
    CapsuleCollider2D _capsuleCollider2D;
    private float gravityScaleAtStart;

    private bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        gravityScaleAtStart = _rigidbody2D.gravityScale;
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
        ClimbLadder();
        Die();
    }
    void OnMove(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }

        moveInput = value.Get<Vector2>();
        Debug.Log(">>>>> Move Input: " +  moveInput);
        // moveInput
        // (1, 0) -> Right
        // (-1, 0) -> Left
        // (0, 1) -> Up
        // (0, -1) -> Down
    }

    void OnJump(InputValue value)
    {
        var isTouchingGround = _capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"));
        if (!isTouchingGround) return;
        if (value.isPressed)
        {
            Debug.Log(">>>>> Jump");
            _rigidbody2D.velocity += new Vector2(0, jumpSpeed);
        }
        if (!isAlive)
        {
            return;
        }

    }

    // Dieu khien chuyen dong cua nv
    void Run()
    {
        var moveVelocity = new Vector2(moveInput.x * moveSpeed, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = moveVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(_rigidbody2D.velocity.x) > Mathf.Epsilon;
        _animator.SetBool("isRunning", playerHasHorizontalSpeed);


    }
    //Abs: gia tri tuyet doi
    //Sign: dau cua gia tri
    //Epilon: gia tri nho nhat co the so sanh

    //Xoay huong nv theo chieu chuyen dong
    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(_rigidbody2D.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(_rigidbody2D.velocity.x), 1f);
        }
    }

    //Leo thang
    void ClimbLadder()
    {
        var isTouchingLadder = _capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Climbing"));
        if (!isTouchingLadder)
        {
            _rigidbody2D.gravityScale = gravityScaleAtStart;
            _animator.SetBool("isClimbing", false);
            return;
        }
        var climbVelocity = new Vector2(_rigidbody2D.velocity.x, moveInput.y * climbSpeed);
        _rigidbody2D.velocity = climbVelocity;

        //Dieu khien animation leo thang
        bool playerHasVerticalSpeed = Mathf.Abs(_rigidbody2D.velocity.y) > Mathf.Epsilon;
        _animator.SetBool("isClimbing", playerHasVerticalSpeed);
        //Tat gravity khi leo thang
        _rigidbody2D.gravityScale = 0;
    }

    void Die()
    {
        var isTouchingEnemy =_capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemy"));
        if (isTouchingEnemy)
        {
            isAlive = false;
            _animator.SetTrigger("Dying");
            _rigidbody2D.velocity = new Vector2(0, 0);
        }
    }
}
