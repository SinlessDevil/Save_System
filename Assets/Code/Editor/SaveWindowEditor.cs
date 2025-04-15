#if UNITY_EDITOR
using System;
using System.IO;
using System.Text;
using Code.Infrastructure.Services.PersistenceProgress.Player;
using Sirenix.OdinInspector.Editor;
using Sirenix.Serialization;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace Code.Editor
{
    public class SaveWindowEditor : OdinEditorWindow
    {
        private const string PlayerPrefsKey = "PlayerData";
        private const string JsonFileName = "player_data.json";

        private string SavePath => Application.persistentDataPath;
        private string JsonFilePath => Path.Combine(SavePath, JsonFileName);

        private Vector2 scrollPrefs;
        private Vector2 scrollJson;

        private string DecodedPrefsData;
        private string DecodedJsonData;

        private string PrefsMessage = "❌ No PlayerPrefs data found.";
        private string JsonMessage = "❌ No JSON file found.";

        [MenuItem("Tools/Save Window Editor")]
        private static void OpenWindow()
        {
            var window = GetWindow<SaveWindowEditor>();
            window.titleContent = new GUIContent("Save Window Editor");
            window.minSize = new Vector2(500, 600);
            window.Show();
        }

        private void OnEnable()
        {
            Refresh();
        }

        protected override void DrawEditor(int index)
        {
            DrawSection("🧠 PlayerPrefs Preview", SavePath, PrefsMessage, DecodedPrefsData, ref scrollPrefs,
                Refresh, DeletePlayerPrefs);

            GUILayout.Space(20);

            DrawSection("📄 JSON File Preview", JsonFilePath, JsonMessage, DecodedJsonData, ref scrollJson,
                Refresh, DeleteJson);
        }

        private void DrawSection(string title, string path, string message, string data, ref Vector2 scrollPos,
            Action refreshAction,
            Action deleteAction)
        {
            SirenixEditorGUI.Title(title, null, TextAlignment.Left, true);
            SirenixEditorGUI.BeginBox();

            EditorGUILayout.LabelField("📁 Save Location", EditorStyles.boldLabel);
            EditorGUILayout.HelpBox(path, MessageType.Info);

            GUILayout.Space(10);

            if (!string.IsNullOrEmpty(data))
            {
                scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Height(300));
                EditorGUILayout.TextArea(data, GUILayout.ExpandHeight(true));
                EditorGUILayout.EndScrollView();
            }
            else
            {
                EditorGUILayout.HelpBox(message, MessageType.Warning);
            }

            GUILayout.Space(10);
            GUI.backgroundColor = new Color(0.6f, 0.9f, 1f);
            if (GUILayout.Button("🔄 Refresh", GUILayout.Height(35)))
                refreshAction.Invoke();

            GUILayout.Space(5);
            GUI.backgroundColor = new Color(1f, 0.4f, 0.4f);
            if (GUILayout.Button("🗑 Delete", GUILayout.Height(35)))
                deleteAction.Invoke();

            GUI.backgroundColor = Color.white;
            SirenixEditorGUI.EndBox();
        }

        private void Refresh()
        {
            RefreshPlayerPrefs();
            RefreshJsonFile();
            Repaint();
        }

        private void RefreshPlayerPrefs()
        {
            DecodedPrefsData = string.Empty;

            if (PlayerPrefs.HasKey(PlayerPrefsKey))
            {
                try
                {
                    string base64 = PlayerPrefs.GetString(PlayerPrefsKey);
                    byte[] data = Convert.FromBase64String(base64);
                    var deserialized = Sirenix.Serialization.SerializationUtility.DeserializeValue<PlayerData>(data, DataFormat.JSON);
                    string json = Encoding.UTF8.GetString(
                        Sirenix.Serialization.SerializationUtility.SerializeValue(deserialized, DataFormat.JSON)
                    );
                    DecodedPrefsData = json;
                    PrefsMessage = string.Empty;
                }
                catch (Exception e)
                {
                    DecodedPrefsData = $"❌ Failed to decode PlayerPrefs:\n{e.Message}";
                    PrefsMessage = "❌ PlayerPrefs data decode failed.";
                }
            }
            else
            {
                PrefsMessage = "❌ No PlayerPrefs data found.";
            }
        }

        private void RefreshJsonFile()
        {
            DecodedJsonData = string.Empty;

            if (File.Exists(JsonFilePath))
            {
                try
                {
                    DecodedJsonData = File.ReadAllText(JsonFilePath);
                    JsonMessage = string.Empty;
                }
                catch (Exception e)
                {
                    DecodedJsonData = $"❌ Failed to read JSON:\n{e.Message}";
                    JsonMessage = "❌ Failed to load JSON file.";
                }
            }
            else
            {
                JsonMessage = "❌ No JSON file found.";
            }
        }


        private void DeletePlayerPrefs()
        {
            if (PlayerPrefs.HasKey(PlayerPrefsKey))
            {
                PlayerPrefs.DeleteKey(PlayerPrefsKey);
                PlayerPrefs.Save();
                Debug.Log("🧹 PlayerPrefs deleted.");
                Refresh();
            }
        }

        private void DeleteJson()
        {
            if (File.Exists(JsonFilePath))
            {
                File.Delete(JsonFilePath);
                Debug.Log("🧹 JSON file deleted.");
                Refresh();
            }
        }
    }
}
#endif