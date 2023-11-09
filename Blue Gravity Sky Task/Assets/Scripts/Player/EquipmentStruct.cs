using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravityStudios
{
    [Serializable]
    public struct EquipmentStruct
    {
        [SerializeField] private SpriteRenderer _hood;
        [SerializeField] private SpriteRenderer _shoulderL;
        [SerializeField] private SpriteRenderer _shoulderR;
        [SerializeField] private SpriteRenderer _top;
        [SerializeField] private SpriteRenderer _botton;
    }
}
