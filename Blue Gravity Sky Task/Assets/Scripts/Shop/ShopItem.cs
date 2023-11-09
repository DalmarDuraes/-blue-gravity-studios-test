using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BlueGravityStudios
{
    public class ShopItem : MonoBehaviour
    {
        [SerializeField] private Image _shopImage;
        [SerializeField] private TextMeshProUGUI _itemPriceTxt;
        [SerializeField] private TextMeshProUGUI _itemNameTxt;
        
        private ShopItemScriptable _shopItemScriptable;

        private Sprite _itemSprite;
        private Sprite _secondaryItemSprite;
        private string _itemName;
        private int _itemPrice;
        private ItemType _itemType;

        public void SetShopItemScriptable(ShopItemScriptable shopItemScriptable) =>
            _shopItemScriptable = shopItemScriptable;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            _itemSprite = _shopItemScriptable.ItemSprite;
            _secondaryItemSprite = _shopItemScriptable.SecondaryItemSprite;
            _itemName = _shopItemScriptable.ItemName;
            _itemPrice = _shopItemScriptable.ItemPrice;
            _itemType = _shopItemScriptable.ItemType;

            _itemNameTxt.text = _itemName;
            _itemPriceTxt.text = _itemPrice.ToString();
            _shopImage.sprite = _itemSprite;
        }
    }

}