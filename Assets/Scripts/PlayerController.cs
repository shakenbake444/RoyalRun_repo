using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 movement;
    Rigidbody rb;
    [SerializeField] private int moveSpeed;
    private Vector3 moveVector;
    private Vector3 moveToPosition;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Move(InputAction.CallbackContext context)
    {
            movement = context.ReadValue<Vector2>();
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
        moveToPosition = rb.position + moveVector * (moveSpeed * Time.fixedDeltaTime);
        
        rb.MovePosition(new Vector3(Mathf.Clamp(moveToPosition.x, -3.8f, 3.8f), 0, Mathf.Clamp(moveToPosition.z, -0.4f, 2f)));
    }
}
