using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravityStudios
{
    [Serializable]
    public struct EquipmentStruct
    {
        [SerializeField] private ItemScriptable _hood;
        [SerializeField] private ItemScriptable _shoulderL;
        [SerializeField] private ItemScriptable _shoulderR;
        [SerializeField] private ItemScriptable _top;
        [SerializeField] private ItemScriptable _botton;
    }
}
