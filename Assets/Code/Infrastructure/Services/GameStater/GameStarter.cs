using Code.Infrastructure.Factory;
using Code.Infrastructure.Services.PersistenceProgress;
using Code.Infrastructure.Services.PersistenceProgress.Player;
using Code.Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace Code.Infrastructure.Services.GameStater
{
    public class GameStarter : IGameStarter
    {
        private readonly IPersistenceProgressService _progressService;
        private readonly ISaveLoadFacade _saveLoadFacade;
        private readonly IUIFactory _uiFactory;
        
        public GameStarter(
            IPersistenceProgressService progressService,
            ISaveLoadFacade saveLoadFacade, 
            IUIFactory uiFactory)
        {
            _progressService = progressService;
            _saveLoadFacade = saveLoadFacade;
            _uiFactory = uiFactory;
        }

        public void Initialize()
        {
            Debug.Log("GameStarter.Initialize");
            
            InitProgress();
            InitUI();
            
            SetUpRandomData();
            _saveLoadFacade.SaveProgress(SaveMethod.PlayerPrefs);
            
            SetUpRandomData();
            _saveLoadFacade.SaveProgress(SaveMethod.Json);
        }
        
        private void InitProgress()
        {
            _progressService.PlayerData = LoadProgress() ?? SetUpBaseProgress();   
        }
        
        private void InitUI()
        {
            _uiFactory.CreateUIRoot();
            _uiFactory.CreateGameHud();
        }
        
        private PlayerData LoadProgress()
        {
            Debug.Log("LoadProgress");

            return _saveLoadFacade.Load(SaveMethod.PlayerPrefs);
        }

        private PlayerData SetUpBaseProgress()
        {
            Debug.Log("InitializeProgress");
            var progress = new PlayerData();
            _progressService.PlayerData = progress;
            return progress;
        }
        
        private void SetUpRandomData()
        {
            var progress = new PlayerData
            {
                PlayerName = $"Player_{Random.Range(1, 100)}",
                Level = Random.Range(1, 51),
                Health = Random.Range(0f, 100f),
                HasPremium = Random.value > 0.5f,
                LastLoginTime = System.DateTime.Now,

                Position = new Vector3(
                    Random.Range(-10f, 10f),
                    Random.Range(-10f, 10f),
                    Random.Range(-10f, 10f)
                ),

                Settings = new GameSettings
                {
                    MusicVolume = Random.Range(0f, 1f),
                    SfxVolume = Random.Range(0f, 1f),
                    IsVibrationEnabled = Random.value > 0.5f,
                    Resolution = new ResolutionSettings
                    {
                        Width = Random.Range(800, 2560),
                        Height = Random.Range(600, 1440),
                        Fullscreen = Random.value > 0.5f
                    }
                },

                Inventory = new InventoryData
                {
                    Coins = Random.Range(0, 1000),
                    Gems = Random.Range(0, 100),
                    Items = new InventoryItem[]
                    {
                        new() { Id = "sword_01", Count = Random.Range(1, 3) },
                        new() { Id = "potion_hp", Count = Random.Range(1, 10) },
                        new() { Id = "shield_02", Count = Random.Range(1, 5) }
                    }
                },

                Quests = new QuestProgress[]
                {
                    new() { QuestId = "quest_001", IsCompleted = Random.value > 0.5f, Progress = Random.Range(0f, 1f) },
                    new() { QuestId = "quest_002", IsCompleted = Random.value > 0.5f, Progress = Random.Range(0f, 1f) }
                }
            };

            _progressService.PlayerData = progress;

            Debug.Log("✅ Random player data saved.");
        }
    }
}