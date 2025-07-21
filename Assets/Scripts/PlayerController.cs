using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 movement;
    Rigidbody rb;
    [SerializeField] private int moveSpeed;
    private Vector3 moveVector;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Move(InputAction.CallbackContext context)
    {
            movement = context.ReadValue<Vector2>();
            Debug.Log(movement);
            moveVector.x = movement.x;
            moveVector.z = movement.y;
    }

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //rb.MovePosition(movement * (Time.deltaTime * moveSpeed));
        rb.MovePosition(rb.position + moveVector * (moveSpeed * Time.fixedDeltaTime));
    }
}
