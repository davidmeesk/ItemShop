using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private float funds = 1000f;

    public delegate void EquipClothing(RuntimeAnimatorController animations);
    public event EquipClothing equipClothes, equipHat;

    public delegate void UpdateFunds(float funds);
    public event UpdateFunds updateFunds;

    public enum ClothingType
    {
        Hat,Body
    }

    [System.Serializable]
    public struct ClothingItem
    {
        public string name;
        public RuntimeAnimatorController animations;
        public ClothingType clothingType;
        public bool owned;
    }

    [SerializeField]
    private ClothingItem[] items;

    private void Start()
    {
        CharacterAnimator characterAnimator = GetComponent<CharacterAnimator>();
        equipClothes += characterAnimator.EquipClothing;
        equipHat += characterAnimator.EquipHat;
    }

    public void PurchaseItem(string itemName, float itemPrice)
    {
        if(itemPrice <= funds)
        {
            foreach (ClothingItem item in items)
            {
                if(item.name == itemName)
                {
                    if (!item.owned)
                    {
                        funds -= itemPrice;
                        switch (item.clothingType)
                        {
                            case ClothingType.Body:
                                equipClothes(item.animations);
                                break;
                            case ClothingType.Hat:
                                equipHat(item.animations);
                                break;
                        }
                        updateFunds.Invoke(funds);
                    }
                }
            }
        }
    }
}
