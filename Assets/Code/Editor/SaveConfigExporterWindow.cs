#if UNITY_EDITOR
using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;

namespace Code.Editor
{
    public class SaveConfigExporterWindow : OdinEditorWindow
    {
        private const string FolderName = "ExportedData";

        [InfoBox("Drag any ScriptableObject here and save or load as JSON")]
        [InlineEditor(InlineEditorObjectFieldModes.Boxed)]
        [SerializeField]
        private ScriptableObject _targetAsset;

        private string SaveFolderPath => Path.Combine(Application.dataPath, FolderName);

        private string JsonPath => _targetAsset != null
            ? Path.Combine(SaveFolderPath, _targetAsset.name + ".json")
            : null;

        [MenuItem("Tools/Save Window/Save Config Exporter Window")]
        private static void OpenWindow()
        {
            var window = GetWindow<SaveConfigExporterWindow>();
            window.titleContent = new GUIContent("Save Config Exporter Window");
            window.minSize = new Vector2(500, 400);
            window.Show();
        }

        protected override void OnEnable()
        {
            if (!Directory.Exists(SaveFolderPath))
                Directory.CreateDirectory(SaveFolderPath);
        }

        protected override void DrawEditor(int index)
        {
            SirenixEditorGUI.BeginBox("Target Asset");
            _targetAsset = (ScriptableObject)SirenixEditorFields.UnityPreviewObjectField(
                _targetAsset, typeof(ScriptableObject), true);
            SirenixEditorGUI.EndBox();

            if (_targetAsset == null)
            {
                EditorGUILayout.HelpBox("⚠ Assign a ScriptableObject to export/import as JSON.", MessageType.Warning);
                return;
            }

            GUILayout.Space(10);
            
            base.DrawEditor(index);
            
            SirenixEditorGUI.BeginBox("Save / Load JSON");

            if (GUILayout.Button("💾 Save to JSON", GUILayout.Height(30)))
            {
                try
                {
                    string json = JsonUtility.ToJson(_targetAsset, true);
                    File.WriteAllText(JsonPath, json);
                    Debug.Log($"✅ Saved JSON to: {JsonPath}");
                }
                catch (Exception e)
                {
                    Debug.LogError($"❌ Failed to save JSON: {e}");
                }
            }

            if (GUILayout.Button("📤 Load from JSON", GUILayout.Height(30)))
            {
                try
                {
                    if (!File.Exists(JsonPath))
                    {
                        Debug.LogWarning("❌ JSON file not found.");
                        return;
                    }

                    JsonUtility.FromJsonOverwrite(File.ReadAllText(JsonPath), _targetAsset);
                    EditorUtility.SetDirty(_targetAsset);
                    AssetDatabase.SaveAssets();
                    Debug.Log("📦 Loaded JSON and applied to ScriptableObject.");
                }
                catch (Exception e)
                {
                    Debug.LogError($"❌ Failed to load JSON: {e}");
                }
            }

            SirenixEditorGUI.EndBox();
        }
    }
}
#endif