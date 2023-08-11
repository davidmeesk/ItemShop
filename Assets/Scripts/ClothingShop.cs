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

    public delegate void UpdateFunds(float playerFunds);
    public event UpdateFunds updateFunds;

    public delegate void SellItemByName(string itemName, float price);
    public event SellItemByName sellItemByName;

    private void Start()
    {
        ClothingShopUI clothingShopUI = shopPanel.GetComponent<ClothingShopUI>();
        updateShopUI += clothingShopUI.UpdateUI;
        updateShopUI.Invoke(shopData);

        updateFunds += clothingShopUI.UpdateFunds;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Let the player open the shop menu with the interact button when they enter the trigger
        PlayerInput playerInput = collision.GetComponent<PlayerInput>();
        if (playerInput != null)
            playerInput.interactAction += OpenShop;
        

        //Link the player's inventory to the shop while they are in the trigger
        Inventory playerInventory = collision.GetComponent<Inventory>();
        if (playerInventory != null)
        {
            sellItemByName += playerInventory.PurchaseItem;
            playerInventory.updateFunds += UpdatePlayerFunds;
        }


    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        //Don't let the player open the shop menu when they leave the trigger
        PlayerInput playerInput = collision.GetComponent<PlayerInput>();
        if (playerInput != null)
            playerInput.interactAction -= OpenShop;

        //Remove the link from player's inventory to the shop when they leave the trigger
        Inventory playerInventory = collision.GetComponent<Inventory>();
        if (playerInventory != null)
        {
            sellItemByName -= playerInventory.PurchaseItem;
            playerInventory.updateFunds -= UpdatePlayerFunds;
        }
    }

    private void OpenShop()
    {
        shopPanel.SetActive(true);
    }


    public void SellItem(int itemIndex)
    {
        sellItemByName.Invoke(shopData[itemIndex].clothingName, shopData[itemIndex].price);
    }

    private void UpdatePlayerFunds(float funds)
    {
        updateFunds.Invoke(funds);
    }

}
