using System;
using System.Collections.Generic;

namespace Code.Infrastructure.StaticData
{
    [Serializable]
    public class LevelData
    {
        public int LevelId;
        public string LevelName;
        public int RequiredXP;

        public CurrencyReward Reward;
        public List<string> RewardItems;

        public List<EnemyWave> EnemyWaves;

        public bool IsBossLevel;
        public int UnlockAtLevel;

        public List<Condition> UnlockConditions;

        public List<Buff> ActiveBuffs;

        public SpecialEvent EventData;
    }

    [Serializable]
    public class CurrencyReward
    {
        public int Gold;
        public int Gems;
    }

    [Serializable]
    public class EnemyWave
    {
        public string EnemyType;
        public int Count;
        public float SpawnDelay;
    }

    [Serializable]
    public class Condition
    {
        public string Description;
        public bool RequiresItem;
        public string RequiredItemId;
    }

    [Serializable]
    public class Buff
    {
        public string BuffName;
        public float Duration;
        public float Value;
    }

    [Serializable]
    public class SpecialEvent
    {
        public bool HasEvent;
        public string EventName;
        public string Description;
    }
}