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

        private void OnEnable()
        {
            EventManager.Register<bool>(ShopkeeperEvents.ToggleInteractionTooltip, ToggleInteractionTooltip);
            EventManager.Register<bool>(NPCEvents.ToggleShop, ToggleShop);
        }

        private void OnDisable()
        {
            EventManager.Unregister<bool>(ShopkeeperEvents.ToggleInteractionTooltip, ToggleInteractionTooltip);
            EventManager.Unregister<bool>(NPCEvents.ToggleShop, ToggleShop);
        }

        private void Awake()
        {
            ToggleInteractionTooltip(false);
        }

        private void ToggleInteractionTooltip(bool value)
        {
            _interactionTooltip.SetActive(value);
        }

        public void ToggleShop(bool value) => _npcShop.ToggleShop(value);

    }
}
