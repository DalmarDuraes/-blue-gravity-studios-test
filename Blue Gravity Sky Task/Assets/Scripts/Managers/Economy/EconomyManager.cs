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

        private void OnEnable()
        {
            EventManager.RegisterReturn(EconomyEvents.GetCurrentCoins, GetCurrentCoins);
            EventManager.Register<int>(EconomyEvents.AddCoins, AddCoins);
            EventManager.Register<int>(EconomyEvents.ReduceCoins, ReduceCoins);
        }

        private void OnDisable()
        {
            EventManager.UnregisterReturn(EconomyEvents.GetCurrentCoins, GetCurrentCoins);
            EventManager.Unregister<int>(EconomyEvents.AddCoins, AddCoins);
            EventManager.Unregister<int>(EconomyEvents.ReduceCoins, ReduceCoins);
        }

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

        private int GetCurrentCoins() => _currentCoins;

    }
}
