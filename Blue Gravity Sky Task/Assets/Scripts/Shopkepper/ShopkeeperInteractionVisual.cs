using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperInteractionVisual : MonoBehaviour
{
    [SerializeField] private GameObject _interactionBalloonVisualFeedback;

    private void OnEnable()
    {
        EventManager.Register<bool>(ShopkeeperEvents.ToggleBalloonVisualFeedback, ToggleVisual);
    }

    private void OnDisable()
    {
        EventManager.Unregister<bool>(ShopkeeperEvents.ToggleBalloonVisualFeedback, ToggleVisual);
    }

    private void Awake()
    {
        ToggleVisual(false);
    }

    private void ToggleVisual(bool value)
    {
        _interactionBalloonVisualFeedback.SetActive(value);
    }
}
