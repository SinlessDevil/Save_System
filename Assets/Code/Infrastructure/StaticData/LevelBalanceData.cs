using System.Collections.Generic;
using UnityEngine;

namespace Code.Infrastructure.StaticData
{
    [CreateAssetMenu(fileName = "LevelBalance", menuName = "StaticData/LevelBalance", order = 0)]
    public class LevelBalanceData : ScriptableObject
    {
        public List<LevelData> Levels = new()
        {
            new LevelData
            {
                LevelId = 1,
                LevelName = "Forest Start",
                RequiredXP = 100,
                Reward = new CurrencyReward { Gold = 50, Gems = 5 },
                RewardItems = new List<string> { "sword_wood", "potion_small" },
                IsBossLevel = false,
                UnlockAtLevel = 0,
                EnemyWaves = new List<EnemyWave>
                {
                    new EnemyWave { EnemyType = "goblin", Count = 5, SpawnDelay = 1.0f },
                    new EnemyWave { EnemyType = "orc", Count = 2, SpawnDelay = 2.0f }
                },
                UnlockConditions = new List<Condition>
                {
                    new Condition { Description = "No special condition", RequiresItem = false }
                },
                ActiveBuffs = new List<Buff>
                {
                    new Buff { BuffName = "Beginner’s Luck", Duration = 30f, Value = 1.2f }
                },
                EventData = new SpecialEvent { HasEvent = false }
            },
            new LevelData
            {
                LevelId = 2,
                LevelName = "Cave of Trials",
                RequiredXP = 300,
                Reward = new CurrencyReward { Gold = 100, Gems = 10 },
                RewardItems = new List<string> { "shield_basic", "potion_medium" },
                IsBossLevel = false,
                UnlockAtLevel = 1,
                EnemyWaves = new List<EnemyWave>
                {
                    new EnemyWave { EnemyType = "bat", Count = 8, SpawnDelay = 0.8f },
                    new EnemyWave { EnemyType = "spider", Count = 4, SpawnDelay = 1.2f }
                },
                UnlockConditions = new List<Condition>
                {
                    new Condition { Description = "Defeat Level 1", RequiresItem = false }
                },
                ActiveBuffs = new List<Buff>
                {
                    new Buff { BuffName = "Dark Vision", Duration = 45f, Value = 1.1f }
                },
                EventData = new SpecialEvent { HasEvent = true, EventName = "Darkness Falls", Description = "Visibility is reduced in this level" }
            },
            new LevelData
            {
                LevelId = 3,
                LevelName = "Dragon's Peak",
                RequiredXP = 700,
                Reward = new CurrencyReward { Gold = 300, Gems = 25 },
                RewardItems = new List<string> { "dragon_slayer", "revive_token" },
                IsBossLevel = true,
                UnlockAtLevel = 2,
                EnemyWaves = new List<EnemyWave>
                {
                    new EnemyWave { EnemyType = "dragon", Count = 1, SpawnDelay = 5f }
                },
                UnlockConditions = new List<Condition>
                {
                    new Condition { Description = "Must own Fire Shield", RequiresItem = true, RequiredItemId = "fire_shield" }
                },
                ActiveBuffs = new List<Buff>
                {
                    new Buff { BuffName = "Boss Rage", Duration = 60f, Value = 2.0f }
                },
                EventData = new SpecialEvent { HasEvent = true, EventName = "Skyfall", Description = "Fireballs rain every 10 seconds" }
            }
        };
    }
}
