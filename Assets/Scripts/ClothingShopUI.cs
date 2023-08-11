using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ClothingShopUI : MonoBehaviour
{
    [System.Serializable]
    public struct ClothingInfo
    {
        public Image icon;
        public TMP_Text clothingName;
        public TMP_Text price;
        public bool purchased;

    }
    public ClothingInfo[] clothing;

    public TMP_Text fundsIndicator;

    internal void UpdateUI(ClothingShop.ClothingData[] clothingData)
    {
        for(int clothingIndex = 0; clothingIndex < clothingData.Length; clothingIndex++)
        {
            clothing[clothingIndex].icon.sprite = clothingData[clothingIndex].icon;
            clothing[clothingIndex].clothingName.text = clothingData[clothingIndex].clothingName;
            clothing[clothingIndex].price.text = clothingData[clothingIndex].price.ToString();
            clothing[clothingIndex].purchased = clothingData[clothingIndex].purchased;
        }
    }

    internal void UpdateFunds(float playerFunds)
    {
        fundsIndicator.text = playerFunds.ToString() + " G";
    }
}
