using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public delegate void StartedMoving(Vector2 direction);
    public event StartedMoving startedMoving;

    public delegate void InteractAction();
    public event InteractAction interactAction;

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();

        HandleInteractInput();
    }

    private void HandleMovementInput()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;
        startedMoving.Invoke(moveDirection);
    }

    private void HandleInteractInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(interactAction != null)
                interactAction.Invoke();
        }
    }
}