using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrintheMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public float playerSpeed = 2.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * playerSpeed;
    }
    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

   
}
