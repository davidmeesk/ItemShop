using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothingShop : MonoBehaviour
{
    [SerializeField]
    private GameObject shopPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInput playerInput = collision.GetComponent<PlayerInput>();
        if (playerInput != null)
        {
            playerInput.interactAction += OpenShop;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerInput playerInput = collision.GetComponent<PlayerInput>();
        if (playerInput != null)
        {
            playerInput.interactAction -= OpenShop;
        }

    }

    private void OpenShop()
    {
        shopPanel.SetActive(true);
    }
}
