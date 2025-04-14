namespace Scripts.SaveToJson.Struct
{
    [System.Serializable]
    public struct GameDataStruct
    {
        public int characterid;
        public CharacterStruct selectedCharacter;
        public CharacterStruct[] characters;

        public int lastCarIndex;
        public CarStruct selectedCar;
        public CarStruct[] cars;
    }
}