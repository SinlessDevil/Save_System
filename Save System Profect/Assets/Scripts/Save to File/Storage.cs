using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Scripts.SaveToFile.Surrogates;
using UnityEngine;

public class Storage
{
    private string filePath;
    private BinaryFormatter formatter;

    public Storage(){
        var directory = Application.persistentDataPath + "/saves";
        if (!Directory.Exists(directory)){
            Directory.CreateDirectory(directory);
        }
        filePath = directory + "/GameSave.save";
        InitBinaryFormatter();
    }
    private void InitBinaryFormatter(){
        formatter = new BinaryFormatter();
        var selecor = new SurrogateSelector();

        var v3Surrogate = new Vector3SerializationSurrogate();
        var qSurrogate = new QuaternionSerializationSurrogate();

        selecor.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), v3Surrogate);
        selecor.AddSurrogate(typeof(Quaternion), new StreamingContext(StreamingContextStates.All), qSurrogate);

        formatter.SurrogateSelector = selecor;
    }

    public object Load(object saveDataByDefault){
        if (!File.Exists(filePath)){
            if(saveDataByDefault != null){
                Save(saveDataByDefault);
            }
            return saveDataByDefault;
        }

        var file = File.Open(filePath, FileMode.Open);
        var savedData = formatter.Deserialize(file);
        file.Close();
        return savedData;
    }
    public void Save(object saveData){
        var file = File.Create(filePath);
        formatter.Serialize(file, saveData);
        file.Close();
    }
}
