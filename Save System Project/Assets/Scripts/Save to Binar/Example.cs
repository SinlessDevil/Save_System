using UnityEngine;

namespace Scripts.SaveToFile{
    public class Example : MonoBehaviour{
        #region Variable Data
        [SerializeField] private string _name;
        [Range(1, 10)] [SerializeField] private int _speed;
        [Range(1, 100)] [SerializeField] private float _progression;
        [SerializeField] private bool _isMode;
        [Space]
        [Range(1, 10)] [SerializeField] private int[] _slots = new int[10];
        [Space]
        [SerializeField] private Vector3 _position;
        [SerializeField] private Quaternion _rotation;
        #endregion

        private Storage _storage;
        private GameData _gameData;

        private void Start(){
            _storage = new Storage();
            LoadData();
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

        #region Save/Load Methods
        private void SaveData(){
            _gameData.speed = _speed;
            _gameData.name = _name;
            _gameData.numberslots = _slots;
            _gameData.progressFill = _progression;
            _gameData.isMode = _isMode;

            _gameData.position = _position;
            _gameData.rotation = _rotation;

            _storage.Save(_gameData);
            Debug.Log("Game saved ..... ");
        }

        private void LoadData(){
            _gameData = (GameData)_storage.Load(new GameData());

            _speed = _gameData.speed;
            _name = _gameData.name;
            _slots = _gameData.numberslots;
            _progression = _gameData.progressFill;
            _isMode = _gameData.isMode;

            _position = _gameData.position;
            _rotation = _gameData.rotation;

            Debug.Log("Game Loaded ..... ");
        }
        #endregion
    }
}
