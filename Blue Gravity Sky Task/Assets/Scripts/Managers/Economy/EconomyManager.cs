using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravityStudios
{
    public class EconomyManager : MonoBehaviour
    {
        [SerializeField] private int _startCoins;
        private int _currentCoins;

        private void Awake()
        {
            _currentCoins = _startCoins;
            TriggerUpdateCoinTxt();
        }

        private void AddCoins(int value)
        {
            _currentCoins += value;
            TriggerUpdateCoinTxt();
        }
        
        private void ReduceCoins(int value)
        {
            _currentCoins -= value;
            TriggerUpdateCoinTxt();
        }
        
        private void TriggerUpdateCoinTxt() => EventManager.Trigger<int>(EconomyEvents.UpdateCoinValueVisual, _currentCoins);

    }
}
