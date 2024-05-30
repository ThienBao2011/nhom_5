using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;
    private Rigidbody2D _rigidbody2D;
    Vector2 moveInput;
    private Animator _animator;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();

    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(">>>>> Move Input: " +  moveInput);
        // moveInput
        // (1, 0) -> Right
        // (-1, 0) -> Left
        // (0, 1) -> Up
        // (0, -1) -> Down
    }

    void OnJump()
    {
        Debug.Log(">>>>> Jump");
    }

    // Dieu khien chuyen dong cua nv
    void Run()
    {
        var moveVelocity = new Vector2(x:moveInput.x * moveSpeed, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = moveVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(_rigidbody2D.velocity.x) > Mathf.Epsilon;
        _animator.SetBool(name: "isRunning", playerHasHorizontalSpeed);


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
            transform.localScale = new Vector2(x: Mathf.Sign(_rigidbody2D.velocity.x), y: 1f);
        }
    }

}
