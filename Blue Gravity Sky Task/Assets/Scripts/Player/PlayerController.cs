using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravityStudios
{
    public class PlayerController : MonoBehaviour
    {
        private void Start()
        {
            EventManager.Trigger<PlayerController>(PlayerEvents.SetPlayer, this);
        }
    }
}
