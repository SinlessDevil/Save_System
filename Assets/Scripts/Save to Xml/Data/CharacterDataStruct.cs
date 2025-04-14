namespace Scripts.SaveToXml.Data
{
    [System.Serializable]
    public struct CharacterDataStruct
    {
        public int arg1, arg2;
        public float health;
        public string nameCharacter;
        public bool isActive;

        public float[] proggresses;
        public string[] nameItem;
    }
}
