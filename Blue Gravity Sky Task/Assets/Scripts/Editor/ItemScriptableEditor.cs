using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace BlueGravityStudios
{
    [CustomEditor(typeof(ClothScriptable))]
    public class ItemScriptableEditor : Editor
    {
        private ClothScriptable _item;

        private void OnEnable()
        {
            _item = target as ClothScriptable;
        }

        public override void OnInspectorGUI()
        {

            base.OnInspectorGUI();
            if (_item.ItemSprite == null)
                return;

            Texture2D texture = AssetPreview.GetAssetPreview(_item.ItemSprite);
            GUILayout.Label("", GUILayout.Height(160), GUILayout.Width(160));
            GUI.DrawTexture(GUILayoutUtility.GetLastRect(), texture);
        }
    }
}
