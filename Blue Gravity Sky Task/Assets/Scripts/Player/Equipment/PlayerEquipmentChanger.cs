using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravityStudios
{
    public class PlayerEquipmentChanger : MonoBehaviour
    {
        //[SerializeField] private EquipmentStruct _equipments;
        [SerializeField] private SpriteRenderer _hood;
        [SerializeField] private SpriteRenderer _shoulderL;
        [SerializeField] private SpriteRenderer _shoulderR;
        [SerializeField] private SpriteRenderer _top;
        [SerializeField] private SpriteRenderer _bottom;

        public void ChangeEquipment(ItemScriptable itemScriptable)
        {
            if (itemScriptable.ItemType == ItemType.Cloth)
                ChangeCloth((ClothScriptable)itemScriptable);
     
        }

        private void ChangeCloth(ClothScriptable clothScriptable)
        {
            switch (clothScriptable.ClothType)
            {
                case ClothType.Hood:
                    _hood.sprite = clothScriptable.ItemSprite;
                    break;
                
                case ClothType.Shoulder:
                    _shoulderL.sprite = clothScriptable.ItemSprite;
                    _shoulderR.sprite = clothScriptable.SecondaryItemSprite;
                    break;
                
                case ClothType.Top:
                    _top.sprite = clothScriptable.ItemSprite;
                    break;
                
                case ClothType.Bottom:
                    _bottom.sprite = clothScriptable.ItemSprite;
                    break;
                
                default:
                    Debug.LogError($"Did not found cloth type: {clothScriptable.ClothType}");
                        break;
            }
        }
    }
}
