using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BlueGravityStudios
{
    public class ShopItem : MonoBehaviour
    {
        [SerializeField] private Image _shopImage;
        private ShopItemScriptable _shopItemScriptable;

        public void SetShopItemScriptable(ShopItemScriptable shopItemScriptable) =>
            _shopItemScriptable = shopItemScriptable;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            _shopImage.sprite = _shopItemScriptable.ItemSprite;
        }
    }

}