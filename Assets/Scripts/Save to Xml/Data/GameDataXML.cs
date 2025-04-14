using UnityEngine;
using System;

namespace Scripts.SaveToXml.Data
{
    [Serializable]
    public class GameDataXML
    {
        public Vector3 position;
        public Quaternion rotation;

        public int number;
        public float percent;
        public string username;
        public bool isActive;

        public int[] slots;
        public bool[] activeSlots;

        public CharacterDataStruct character;
    }
}
