using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EconomyVisual : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinTxt;

    private void OnEnable()
    {
        EventManager.Register<int>(EconomyEvents.UpdateCoinValueVisual, UpdateCoinTxt);
    }

    private void OnDisable()
    {
        EventManager.Unregister<int>(EconomyEvents.UpdateCoinValueVisual, UpdateCoinTxt);
    }

    private void UpdateCoinTxt(int value)
    {
        _coinTxt.text = $"x{value}";
    }
}
