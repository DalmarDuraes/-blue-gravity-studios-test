using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace BlueGravityStudios
{
    [CustomEditor(typeof(ShopItemScriptable))]
    public class ShopItemScriptableEditor : Editor
    {
        private ShopItemScriptable _shopItem;

        private void OnEnable()
        {
            _shopItem = target as ShopItemScriptable;
        }

        public override void OnInspectorGUI()
        {

            base.OnInspectorGUI();
            if (_shopItem.ItemSprite == null)
                return;

            Texture2D texture = AssetPreview.GetAssetPreview(_shopItem.ItemSprite);
            GUILayout.Label("", GUILayout.Height(80), GUILayout.Width(80));
            GUI.DrawTexture(GUILayoutUtility.GetLastRect(), texture);
        }
    }
}
