using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BlueGravityStudios
{
    public class Item : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI _itemNameTxt;
        [SerializeField] protected TextMeshProUGUI _itemPriceTxt;
        [SerializeField] private Image _itemSpriteOnUi;
        protected string _itemName;

        protected ItemScriptable _itemScriptable;
        protected int _itemPrice;
        protected int _itemSellPrice;
        protected Sprite _itemSprite;
        protected Sprite _secondaryItemSprite;
        protected Sprite _spriteForPanels;
        protected ItemType _itemType;

        public ItemScriptable ItemScriptable => _itemScriptable;
        public int ItemPrice => _itemPrice;
        public int ItemSellPrice =>_itemSellPrice;
        public Sprite ItemSprite => _itemSprite;
        public Sprite SecondaryItemSprite => _secondaryItemSprite;
        protected Sprite SpriteForPanels => _spriteForPanels;
        public ItemType ItemType => _itemType;

        public void CallInit()
        {
            Init();
        }
        
        protected virtual void Init()
        {
            _itemSprite = _itemScriptable.ItemSprite;
            _secondaryItemSprite = _itemScriptable.SecondaryItemSprite;
            _spriteForPanels = _itemScriptable.SpriteForPanels;
            _itemName = _itemScriptable.ItemName;
            _itemPrice = _itemScriptable.ItemPrice;
            _itemType = _itemScriptable.ItemType;
            _itemNameTxt.text = _itemName;
            _itemPriceTxt.text = _itemPrice.ToString();
            _itemSellPrice = _itemPrice / 2;
            _itemSpriteOnUi.sprite = _spriteForPanels;
        }
        
        public void SetItemScriptable(ItemScriptable itemScriptable) => _itemScriptable = itemScriptable;
        public void Disable() => gameObject.SetActive(false);
    }
}
