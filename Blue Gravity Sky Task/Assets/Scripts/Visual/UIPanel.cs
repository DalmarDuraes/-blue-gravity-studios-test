using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravityStudios
{
    public class UIPanel : MonoBehaviour
    {
        [SerializeField] private bool _activeOnStartup;
        private void Awake()
        {
            ToggleUI(_activeOnStartup);
        }
        public void ToggleUI(bool value) => gameObject.SetActive(value);
    }
}