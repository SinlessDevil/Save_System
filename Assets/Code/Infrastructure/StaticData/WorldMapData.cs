using System.Collections.Generic;
using UnityEngine;

namespace Code.Infrastructure.StaticData
{
    [CreateAssetMenu(fileName = "WorldMapData", menuName = "StaticData/WorldMapData", order = 1)]
    public class WorldMapData : ScriptableObject
    {
        public List<RegionData> Regions = new()
        {
            new RegionData
            {
                RegionId = "northern_vale",
                DisplayName = "Northern Vale",
                Biome = BiomeType.Snowy,
                UnlockCost = new CurrencyCost { Gold = 1000, Gems = 25 },
                PointsOfInterest = new List<PointOfInterest>
                {
                    new PointOfInterest { Name = "Frozen Lake", IsLandmark = true, Description = "A mysterious lake that never thaws." },
                    new PointOfInterest { Name = "Abandoned Watchtower", IsLandmark = false, Description = "Ruins of a long-forgotten guard post." }
                },
                TravelEvents = new List<WorldEvent>
                {
                    new WorldEvent { EventType = "Blizzard", Chance = 0.3f, EffectDescription = "Slows down travel by 50%." }
                }
            },
            new RegionData
            {
                RegionId = "sunken_dunes",
                DisplayName = "Sunken Dunes",
                Biome = BiomeType.Desert,
                UnlockCost = new CurrencyCost { Gold = 2000, Gems = 40 },
                PointsOfInterest = new List<PointOfInterest>
                {
                    new PointOfInterest { Name = "Buried Temple", IsLandmark = true, Description = "An ancient temple beneath the sands." },
                    new PointOfInterest { Name = "Mirage Oasis", IsLandmark = false, Description = "Sometimes it's real, sometimes it's not." }
                },
                TravelEvents = new List<WorldEvent>
                {
                    new WorldEvent { EventType = "Sandstorm", Chance = 0.4f, EffectDescription = "Visibility drops and enemies ambush more often." }
                }
            }
        };
    }

    [System.Serializable]
    public class RegionData
    {
        public string RegionId;
        public string DisplayName;
        public BiomeType Biome;
        public CurrencyCost UnlockCost;
        public List<PointOfInterest> PointsOfInterest;
        public List<WorldEvent> TravelEvents;
    }

    [System.Serializable]
    public class CurrencyCost
    {
        public int Gold;
        public int Gems;
    }

    [System.Serializable]
    public class PointOfInterest
    {
        public string Name;
        public bool IsLandmark;
        public string Description;
    }

    [System.Serializable]
    public class WorldEvent
    {
        public string EventType;
        public float Chance;
        public string EffectDescription;
    }

    public enum BiomeType
    {
        Forest,
        Desert,
        Snowy,
        Volcanic,
        Swamp
    }
}
