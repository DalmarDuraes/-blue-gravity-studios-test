using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravityStudios
{
    public abstract class Variable<T> : ScriptableObject, ISerializationCallbackReceiver
    {
        public T Value { get; set; }
        public T DefaultValue; 

        public void OnBeforeSerialize() { }

        public void OnAfterDeserialize()
        {
            Value = DefaultValue;
        }
    }
}