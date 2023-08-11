using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private float funds = 1000f;

    public delegate void EquipClothing(RuntimeAnimatorController animations);
    public event EquipClothing equipClothes, equipHat;

    public delegate void PurchasedItem(string itemName, float funds);
    public event PurchasedItem purchasedItem;

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
            for (int clothingIndex =0; clothingIndex< items.Length; clothingIndex++ )
            {
                ClothingItem item = items[clothingIndex];
                if(item.name == itemName)
                {
                    if (!item.owned)
                    {
                        funds -= itemPrice;
                        purchasedItem.Invoke(itemName, funds);
                    }
                    switch (item.clothingType)
                    {
                        case ClothingType.Body:
                            equipClothes(item.animations);
                            break;
                        case ClothingType.Hat:
                            equipHat(item.animations);
                            break;
                    }
                    
                    items[clothingIndex].owned = true;


                }
            }
        }
    }
}
