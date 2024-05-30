using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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


}
