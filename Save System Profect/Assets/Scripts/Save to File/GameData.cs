using System;
using UnityEngine;

namespace Scripts.SaveToFile{
    [Serializable]
    public class GameData {

        public int[] numberslots = new int[10];

        public int speed;
        public float progressFill;
        public bool isMode;
        public string name;

        public Vector3 position;
        public Quaternion rotation;

        public GameData(){
            for (int i = 0; i < numberslots.Length; i++)
                numberslots[i] = 1;

            speed = 10;
            progressFill = 100f;
            isMode = true;
            name = "User";
            position = Vector3.up;
            rotation = Quaternion.identity;
        }
    }
}
