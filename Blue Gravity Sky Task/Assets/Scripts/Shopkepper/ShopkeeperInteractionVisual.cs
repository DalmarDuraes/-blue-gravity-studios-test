using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperInteractionVisual : MonoBehaviour
{
    [SerializeField] private GameObject _interactionTooltip;
    [SerializeField] private GameObject _npcShop;

    private void OnEnable()
    {
        EventManager.Register<bool>(ShopkeeperEvents.ToggleInteractionTooltip, ToggleInteractionTooltip);
        EventManager.Register<bool>(ShopkeeperEvents.ToggleShop, ToggleShop);
    }

    private void OnDisable()
    {
        EventManager.Unregister<bool>(ShopkeeperEvents.ToggleInteractionTooltip, ToggleInteractionTooltip);
        EventManager.Unregister<bool>(ShopkeeperEvents.ToggleShop, ToggleShop);
    }

    private void Awake()
    {
        ToggleInteractionTooltip(false);
        ToggleShop(false);
    }

    private void ToggleInteractionTooltip(bool value)
    {
        _interactionTooltip.SetActive(value);
    }

    private void ToggleShop(bool value)
    {
        _npcShop.SetActive(value);
    }
    
   
}
