using System;
using UnityEngine;

namespace Code.Infrastructure.Services.PersistenceProgress.Player
{
    [Serializable]
    public class PlayerData
    {
        public string PlayerName = "TestPlayer";
        public int Level = 5;
        public float Health = 82.3f;
        public bool HasPremium = true;
        public DateTime LastLoginTime = DateTime.Now;
        public Vector3 Position = new Vector3(2.5f, 0, -4.3f);
        
        public GameSettings Settings = new GameSettings();
        public InventoryData Inventory = new InventoryData();
        public QuestProgress[] Quests = new[]
        {
            new QuestProgress { QuestId = "quest_001", IsCompleted = true, Progress = 1.0f },
            new QuestProgress { QuestId = "quest_002", IsCompleted = false, Progress = 0.4f }
        };
    }

    [Serializable]
    public class GameSettings
    {
        public float MusicVolume = 0.8f;
        public float SfxVolume = 0.5f;
        public bool IsVibrationEnabled = true;
        public ResolutionSettings Resolution = new ResolutionSettings();
    }

    [Serializable]
    public class ResolutionSettings
    {
        public int Width = 1920;
        public int Height = 1080;
        public bool Fullscreen = true;
    }

    [Serializable]
    public class InventoryData
    {
        public int Coins = 999;
        public int Gems = 30;
        public InventoryItem[] Items = new[]
        {
            new InventoryItem { Id = "sword_01", Count = 1 },
            new InventoryItem { Id = "shield_02", Count = 1 },
            new InventoryItem { Id = "potion_hp", Count = 5 }
        };
    }

    [Serializable]
    public class InventoryItem
    {
        public string Id;
        public int Count;
    }

    [Serializable]
    public class QuestProgress
    {
        public string QuestId;
        public bool IsCompleted;
        public float Progress;
    }
}