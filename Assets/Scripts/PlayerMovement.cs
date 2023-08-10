using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movementSpeed = 200f;

    public delegate void StartedMoving(Vector2 direction);
    private event StartedMoving startedMoving;

    Vector2 moveDirection = Vector2.zero;

    void OnEnable()
    {
        CharacterAnimator animator = GetComponent<CharacterAnimator>();
        startedMoving += animator.SetMovementAnimation;
    }

    void OnDisable()
    {
        CharacterAnimator animator = GetComponent<CharacterAnimator>();
        startedMoving -= animator.SetMovementAnimation;
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
        startedMoving.Invoke(moveDirection);
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * movementSpeed * Time.fixedDeltaTime;
    }
}
