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
        protected int _itemPrice;
        protected ItemScriptable _itemScriptable;
        

        protected Sprite _itemSprite;
        public Sprite ItemSprite => _itemSprite;

        protected Sprite _secondaryItemSprite;
        public Sprite SecondaryItemSprite => _secondaryItemSprite;

        protected ItemType _itemType;
        public ItemType ItemType => _itemType;

        private void Start()
        {
            Init();
        }

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
