namespace Scripts.SaveToJson.Struct
{
    [System.Serializable]
    public struct CarStruct
    {
        public float speed;
        public int mass;
        public bool isPassenger;

        public string name;
        public int[] doors;
    }
}
