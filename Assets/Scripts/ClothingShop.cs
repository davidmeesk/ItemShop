using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothingShop : MonoBehaviour
{
    [System.Serializable]
    public struct ClothingData
    {
        public Sprite icon;
        public string clothingName;
        public float price;
        public bool purchased;
    }

    [SerializeField]
    private GameObject shopPanel;
    [SerializeField]
    private ClothingData[] shopData;

    public delegate void UpdateUI(ClothingData[] clothingData);
    public event UpdateUI updateShopUI;

    private void Start()
    {
        updateShopUI += shopPanel.GetComponent<ClothingShopUI>().UpdateUI;
        updateShopUI.Invoke(shopData);
    }

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
