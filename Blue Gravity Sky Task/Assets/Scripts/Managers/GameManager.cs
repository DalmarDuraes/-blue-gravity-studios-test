using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravityStudios
{
    public class GameManager : MonoBehaviour
    {
        private PlayerController _player;

        private void OnEnable()
        {
            EventManager.Register<PlayerController>(PlayerEvents.SetPlayer, SetPlayer);
            EventManager.RegisterReturn<PlayerController>(PlayerEvents.GetPlayer, GetPlayer);
        }

        private void OnDisable()
        {
            EventManager.Unregister<PlayerController>(PlayerEvents.SetPlayer, SetPlayer);
            EventManager.UnregisterReturn<PlayerController>(PlayerEvents.GetPlayer, GetPlayer);
        }

        private void SetPlayer(PlayerController player)
        {
            _player = player;
        }

        private PlayerController GetPlayer() => _player;

    }
}