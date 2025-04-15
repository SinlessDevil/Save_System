#if UNITY_EDITOR
using System;
using Sirenix.OdinInspector.Editor;
using Sirenix.Serialization;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;
using SerializationUtility = Sirenix.Serialization.SerializationUtility;

namespace Code.Editor
{
    public class SaveWindowEditor : OdinEditorWindow
    {
        private const string PlayerDataKey = "PlayerData";

        private string savePath => Application.persistentDataPath;
        private Vector2 scrollPos;

        [MenuItem("Tools/Save Window Editor")]
        private static void OpenWindow()
        {
            var window = GetWindow<SaveWindowEditor>();
            window.titleContent = new GUIContent("Save Window Editor");
            window.minSize = new Vector2(500, 600);
            window.Show();
        }

        public string DecodedPlayerData;
        public string Message = "❌ No PlayerData found.";

        private void OnEnable()
        {
            Refresh();
        }

        protected override void DrawEditor(int index)
        {
            EditorGUILayout.Space();

            // Main Box Group
            SirenixEditorGUI.Title("🧠 PlayerPrefs Preview", null, TextAlignment.Left, true);
            SirenixEditorGUI.BeginBox();
            
            EditorGUILayout.LabelField("📁 Save Location", EditorStyles.boldLabel);
            EditorGUILayout.HelpBox(savePath, MessageType.Info);

            EditorGUILayout.Space();
            
            if (!string.IsNullOrEmpty(DecodedPlayerData))
            {
                scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Height(300));
                EditorGUILayout.TextArea(DecodedPlayerData, GUILayout.ExpandHeight(true));
                EditorGUILayout.EndScrollView();
            }
            else
            {
                EditorGUILayout.HelpBox(Message, MessageType.Warning);
            }

            GUILayout.Space(10);

            // Buttons
            GUI.backgroundColor = new Color(0.6f, 0.9f, 1f);
            if (GUILayout.Button("🔄 Refresh", GUILayout.Height(35)))
                Refresh();

            GUILayout.Space(5);

            GUI.backgroundColor = new Color(1f, 0.4f, 0.4f);
            if (GUILayout.Button("🗑 Delete PlayerData", GUILayout.Height(35)))
                DeletePlayerData();

            GUI.backgroundColor = Color.white;

            SirenixEditorGUI.EndBox();
        }

        private void Refresh()
        {
            DecodedPlayerData = string.Empty;

            if (PlayerPrefs.HasKey(PlayerDataKey))
            {
                try
                {
                    string base64 = PlayerPrefs.GetString(PlayerDataKey);
                    byte[] data = Convert.FromBase64String(base64);
                    object deserialized = SerializationUtility.DeserializeValue<object>(data, DataFormat.JSON);
                    DecodedPlayerData = JsonUtility.ToJson(deserialized, true);
                    Message = string.Empty;
                }
                catch (Exception e)
                {
                    DecodedPlayerData = $"❌ Failed to decode PlayerData:\n{e.Message}";
                }
            }
            else
            {
                Message = "❌ No PlayerData found.";
            }

            Repaint();
        }

        private void DeletePlayerData()
        {
            if (PlayerPrefs.HasKey(PlayerDataKey))
            {
                PlayerPrefs.DeleteKey(PlayerDataKey);
                PlayerPrefs.Save();
                Refresh();
                Debug.Log("🧹 PlayerData deleted.");
            }
        }
    }
}
#endif
