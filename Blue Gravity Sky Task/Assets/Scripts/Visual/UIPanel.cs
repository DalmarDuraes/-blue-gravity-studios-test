using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravityStudios
{
    public class UIPanel : MonoBehaviour
    { 
        public void ToggleUI(bool value) => gameObject.SetActive(value);
        public virtual void ToggleUI(bool value, bool openedByPlayer) => gameObject.SetActive(value);
    }
}