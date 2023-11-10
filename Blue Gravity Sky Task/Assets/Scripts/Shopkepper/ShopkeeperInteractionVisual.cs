using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravityStudios
{
    public class ShopkeeperInteractionVisual : MonoBehaviour
    {
        [SerializeField] private GameObject _interactionTooltip;
        [SerializeField] private Shop _npcShop;
        private void Awake()
        {
            ToggleInteractionTooltip(false);
        }

        public void ToggleInteractionTooltip(bool value)
        {
            _interactionTooltip.SetActive(value);
        }

        public void TryToggleShop()
        {
            _npcShop.TryToggleShop();
        }
    }
}
