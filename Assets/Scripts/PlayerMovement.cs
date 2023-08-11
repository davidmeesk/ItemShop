using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movementSpeed = 200f;

    Vector2 moveDirection = Vector2.zero;

    private void OnEnable()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();
        playerInput.startedMoving += MoveCharacter;
    }

    private void OnDisable()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();
        playerInput.startedMoving -= MoveCharacter;
    }

    private void MoveCharacter(Vector2 direction)
    {
        moveDirection = direction;
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * movementSpeed * Time.fixedDeltaTime;
    }
}
