using Scripts.SaveToJson.Struct;
using UnityEngine;
using System;
using System.IO;

namespace Scripts.SaveToJson
{
    public class SaveToJson : MonoBehaviour
    {
        public enum TypePlatform
        {
            PC,
            Android
        }
        public TypePlatform typePlatform;

        [Header("Character")]
        [SerializeField] private int _characterid;
        [SerializeField] private CharacterStruct _selectedCharacter;
        [SerializeField] private CharacterStruct[] _characters;
        [Space(10)]

        [Header("Car")]
        [SerializeField] private int _lastCarIndex;
        [SerializeField] private CarStruct _selectedCar;
        [SerializeField] private CarStruct[] _cars;
        [Space(10)]

        [Header("Save Config")]
        [SerializeField] private string savePath;
        [SerializeField] private string saveFileName = "data.json";

        private void Awake()
        {
            switch (typePlatform)
            {
                case TypePlatform.PC:
                    savePath = Path.Combine(Application.persistentDataPath, saveFileName);
                    break;
                case TypePlatform.Android:
                    savePath = Path.Combine(Application.dataPath, saveFileName);
                    break;
            }

            LoadToFile();
        }

        private void OnEnable()
        {
            ButtonManager.clickButtonSaveData += SaveToFile;
            ButtonManager.clickButtonLoadData += LoadToFile;
        //    ButtonManager.clickButtonDeleteData += OnAllDeleteData;
        }

        private void OnDisable()
        {
            ButtonManager.clickButtonSaveData -= SaveToFile;
            ButtonManager.clickButtonLoadData -= LoadToFile;
          //  ButtonManager.clickButtonDeleteData -= OnAllDeleteData;
        }

        private void SaveToFile()
        {
            GameDataStruct gameData = new GameDataStruct
            {
                characterid = this._characterid,
                selectedCharacter = this._selectedCharacter,
                characters = this._characters,

                lastCarIndex = this._lastCarIndex,
                selectedCar = this._selectedCar,
                cars = this._cars
            };

            string json = JsonUtility.ToJson(gameData, true);

            try
            {
                File.WriteAllText(savePath, json);
            }
            catch(Exception e)
            {
                Debug.Log("{GameLog} => [SaveToJson] - (<color=red>Error</color>) - SaveToFile ->" + e.Message);
            }
        }
        private void LoadToFile()
        {
            if (!File.Exists(savePath))
            {
                Debug.Log("{GameLog} => [SaveToJson] - LoadToFile -> File is Not Found");
                return;
            }

            try
            {
                string json = File.ReadAllText(savePath);

                GameDataStruct gameDaraFromJson = JsonUtility.FromJson<GameDataStruct>(json);
                this._characterid = gameDaraFromJson.characterid;
                this._selectedCharacter = gameDaraFromJson.selectedCharacter;
                this._characters = gameDaraFromJson.characters;

                this._lastCarIndex = gameDaraFromJson.lastCarIndex;
                this._selectedCar = gameDaraFromJson.selectedCar;
                this._cars = gameDaraFromJson.cars;
            }
            catch (Exception e)
            {
                Debug.Log("{GameLog} => [SaveToJson] - (<color=red>Error</color>) - LoadToFile ->" + e.Message);
            }
        }

        private void OnApplicationQuit()
        {
            SaveToFile();
        }

        private void OnApplicationPause(bool pause)
        {
            if(Application.platform == RuntimePlatform.Android)
            {
                SaveToFile();
            }
        }
    }
}

