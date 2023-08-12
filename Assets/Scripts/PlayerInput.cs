using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;
    private int blockingPanels = 0;

    public delegate void StartedMoving(Vector2 direction);
    public event StartedMoving startedMoving;

    public delegate void InteractAction();
    public event InteractAction interactAction;

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();

        HandleInteractInput();

        HandlePauseInput();
    }

    private void HandleMovementInput()
    {
        if (blockingPanels == 0)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");

            Vector2 moveDirection = new Vector2(moveX, moveY).normalized;
            startedMoving.Invoke(moveDirection);
        }
        else
        {
            startedMoving.Invoke(Vector2.zero);
        }
    }

    private void HandleInteractInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(interactAction != null)
                interactAction.Invoke();
        }
    }

    private void HandlePauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenu.activeInHierarchy)
            {
                DisableWalking();
                pauseMenu.SetActive(true);
            }
            else
            {
                EnableWalking();
                pauseMenu.SetActive(false);
            }
        }
    }

    internal void DisableWalking()
    {
        blockingPanels++;
    }

    public void EnableWalking()
    {
        blockingPanels--;
    }
}
