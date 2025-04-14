using System;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using Scripts.SaveToXml.Data;

namespace Scripts.SaveToXml
{
    public class SaveToXmlFile : MonoBehaviour
    {
        [Header("Position Player Variabls")]
        [SerializeField] private Vector3 _position;
        [SerializeField] private Quaternion _rotation;
        [Space(10)]
        [Header("Another Variabls")]
        [SerializeField] private int _number;
        [SerializeField] private float _percent;
        [SerializeField] private string _username;
        [SerializeField] private bool _isActive;
        [Space(10)]
        [Header("Array Variabls")]
        [SerializeField] private int[] _slots;
        [SerializeField] private bool[] _activeSlots;
        [Space(10)]
        [Header("Struct Variabls")]
        [SerializeField] private CharacterDataStruct _character;
        [Space(10)]

        public string fileName = "/XMLWorld.xml";
        public static string savePath { get; private set; }

        private void Start()
        {
            savePath = Application.dataPath;
        }

        private void OnEnable()
        {
            ButtonManager.clickButtonSaveData += SaveData;
            ButtonManager.clickButtonLoadData += LoadData;
            //   ButtonManager.clickButtonDeleteData += OnAllDeleteData;
        }

        private void OnDisable()
        {
            ButtonManager.clickButtonSaveData -= SaveData;
            ButtonManager.clickButtonLoadData -= LoadData;
            //    ButtonManager.clickButtonDeleteData -= OnAllDeleteData;
        }

        public void LoadData()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(GameDataXML));

            using (FileStream fs = new FileStream(savePath + fileName, FileMode.OpenOrCreate))
            {
                GameDataXML wordData = (GameDataXML)formatter.Deserialize(fs);
                this._position = wordData.position;
                this._rotation = wordData.rotation;

                this._number = wordData.number;
                this._percent = wordData.percent;
                this._username = wordData.username;
                this._isActive = wordData.isActive;

                this._slots = wordData.slots;
                this._activeSlots = wordData.activeSlots;

                this._character = wordData.character;
            }
        }
        public void SaveData()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(GameDataXML));

            var data = new GameDataXML()
            {
                   position = this._position,
                   rotation = this._rotation,

                   number = this._number,
                   percent = this._percent,
                   username = this._username,
                   isActive = this._isActive,

                   slots = this._slots,
                   activeSlots = this._activeSlots,

                   character = this._character,
            };

            if (File.Exists(savePath + fileName))
            {
                File.WriteAllText(savePath + fileName, "");
            }

            using (FileStream fs = new FileStream(savePath + fileName, FileMode.OpenOrCreate))
            {
                // сериализуем весь массив people
                formatter.Serialize(fs, data);
            }
        }
    }
}
