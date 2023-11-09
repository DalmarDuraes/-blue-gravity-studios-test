using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BlueGravityStudios
{
    public class Item : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI _itemNameTxt;
        protected string _itemName;
        protected ItemScriptable _itemScriptable;
        public ItemScriptable ItemScriptable => _itemScriptable;
        
        protected int _itemPrice;
        public int ItemPrice => _itemPrice;

        protected Sprite _itemSprite;
        public Sprite ItemSprite => _itemSprite;

        protected Sprite _secondaryItemSprite;
        public Sprite SecondaryItemSprite => _secondaryItemSprite;

        protected ItemType _itemType;
        public ItemType ItemType => _itemType;

        public void CallInit() => Init();
        protected virtual void Init()
        {
            _itemSprite = _itemScriptable.ItemSprite;
            _secondaryItemSprite = _itemScriptable.SecondaryItemSprite;
            _itemName = _itemScriptable.ItemName;
            _itemPrice = _itemScriptable.ItemPrice;
            _itemType = _itemScriptable.ItemType;
            _itemNameTxt.text = _itemName;
        }
        
        public void SetItemScriptable(ItemScriptable itemScriptable) => _itemScriptable = itemScriptable;
    }
}
