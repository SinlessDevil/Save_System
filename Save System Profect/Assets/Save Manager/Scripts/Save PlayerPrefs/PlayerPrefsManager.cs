using UnityEngine;
using System;

public class PlayerPrefsManager : MonoBehaviour
{
    #region Patern Singleton
    public static PlayerPrefsManager instance { get; private set; }

    private void Awake(){
        if (instance == null){
            instance = this;
            return;
        }
    }
    #endregion

    #region Methods Saving Data
    public void SaveIntData(string nameKey, int arg){
        PlayerPrefs.SetInt(nameKey, arg);
        PlayerPrefs.Save();
    }
    public void SaveFloatData(string nameKey, float arg){
        PlayerPrefs.SetFloat(nameKey, arg);
        PlayerPrefs.Save();
    }
    public void SaveStringData(string nameKey, string arg){
        PlayerPrefs.SetString(nameKey, arg);
        PlayerPrefs.Save();
    }
    public void SaveBoolData(string nameKey, bool arg){
        PlayerPrefs.SetInt(nameKey, arg ? 1 : 0);
        PlayerPrefs.Save();
    }

    //  Methods Save Array
    public void SaveArrayIntData(string nameKey, int[] arg){
        for (int i = 0; i < arg.Length; i++){
            PlayerPrefs.SetInt(nameKey + i, arg[i]);
        }
        PlayerPrefs.Save();
    }
    public void SaveArrayFloatData(string nameKey, float[] arg){
        for (int i = 0; i < arg.Length; i++){
            PlayerPrefs.SetFloat(nameKey + i, arg[i]);
        }
        PlayerPrefs.Save();
    }
    public void SaveArrayStringData(string nameKey, string[] arg){
        for (int i = 0; i < arg.Length; i++){
            PlayerPrefs.SetString(nameKey + i, arg[i]);
        }
        PlayerPrefs.Save();
    }
    public void SaveArrayBoolData(string nameKey, bool[] arg){
        for (int i = 0; i < arg.Length; i++){
            PlayerPrefs.SetInt(nameKey + i, arg[i] ? 1 : 0);
        }
        PlayerPrefs.Save();
    }
    //  ------------------
    #endregion

    #region Methods Loading Data
    public int LoadIntData(string nameKey, int arg){
        if (PlayerPrefs.HasKey(nameKey)){
            arg = PlayerPrefs.GetInt(nameKey);
        }
        return arg;
    }
    public float LoadFloatData(string nameKey, float arg){
        if (PlayerPrefs.HasKey(nameKey)){
            arg = PlayerPrefs.GetFloat(nameKey);
        }
        return arg;
    }
    public string LoadStringData(string nameKey, string arg){
        if (PlayerPrefs.HasKey(nameKey)){
            arg = PlayerPrefs.GetString(nameKey);
        }
        return arg;
    }
    public bool LoadBoolData(string nameKey, bool arg){
        int arg1 = 0;
        if (PlayerPrefs.HasKey(nameKey))
        {
            arg1 = PlayerPrefs.GetInt(nameKey);
            arg = Convert.ToBoolean(arg1);
        }
        return arg;
    }
    // Methods Load Array
    public int[] LoadArrayIntData(string nameKey, int[] arg)
    {
        for (int i = 0; i < arg.Length; i++)
        {
            if (PlayerPrefs.HasKey(nameKey + i))
            {
                arg[i] = PlayerPrefs.GetInt(nameKey + i);
            }
        }
        return arg;
    }
    #endregion
}
