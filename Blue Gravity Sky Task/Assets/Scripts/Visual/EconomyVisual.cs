using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BlueGravityStudios
{
    public class EconomyVisual : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinTxt;
        [SerializeField] private Variable<int> _coin;

        private void OnEnable()
        {
            EventManager.Register(EconomyEvents.UpdateCoinValueVisual, UpdateCoinTxt);
        }

        private void OnDisable()
        {
            EventManager.Unregister(EconomyEvents.UpdateCoinValueVisual, UpdateCoinTxt );
        }

        private void UpdateCoinTxt() => _coinTxt.text = $"x{_coin.Value}";
       
    }
}
