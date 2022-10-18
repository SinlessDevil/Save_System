using UnityEngine;

public class TestSavingPlayerPrefs : MonoBehaviour
{
    #region Data Variabls
    [Range(1, 10)] [SerializeField] private int _number = 0;
    [Range(1, 100)] [SerializeField] private float _progressFill = 0.0f;
    [SerializeField] private string _userName = "";
    [SerializeField] private bool _isActive = false;
    [SerializeField] private int[] _slots = new int[9];
    #endregion

    private void Start()
    {
        LoadDataByDefould();
        OnLoadData();
    }

    private void OnEnable()
    {
        ButtonManager.clickButtonSaveData += OnSaveData;
        ButtonManager.clickButtonLoadData += OnLoadData;
        ButtonManager.clickButtonDeleteData += OnAllDeleteData;
    }

    private void OnDisable()
    {
        ButtonManager.clickButtonSaveData -= OnSaveData;
        ButtonManager.clickButtonLoadData -= OnLoadData;
        ButtonManager.clickButtonDeleteData -= OnAllDeleteData;
    }

    public void OnSaveData()
    {
        PlayerPrefsManager.instance.SaveIntData(DictionarySaveKey.nameKeyNumber, _number);
        PlayerPrefsManager.instance.SaveFloatData(DictionarySaveKey.nameKeyProgress, _progressFill);
        PlayerPrefsManager.instance.SaveStringData(DictionarySaveKey.nameKeyName, _userName);
        PlayerPrefsManager.instance.SaveBoolData(DictionarySaveKey.nameKeyMode, _isActive);

        PlayerPrefsManager.instance.SaveArrayIntData(DictionarySaveKey.nameKeySlots, _slots);

        Debug.Log("Saving ... ");
    }

    public void OnLoadData()
    {
        _number = PlayerPrefsManager.instance.LoadIntData(DictionarySaveKey.nameKeyNumber, _number);
        _progressFill = PlayerPrefsManager.instance.LoadFloatData(DictionarySaveKey.nameKeyProgress, _progressFill);
        _userName = PlayerPrefsManager.instance.LoadStringData(DictionarySaveKey.nameKeyName, _userName);
        _isActive = PlayerPrefsManager.instance.LoadBoolData(DictionarySaveKey.nameKeyMode, _isActive);
        _slots = PlayerPrefsManager.instance.LoadArrayIntData(DictionarySaveKey.nameKeySlots, _slots);

        Debug.Log("Loading ... ");

        Debug.Log("Number :" + _number);
        Debug.Log("ProgressFill" + _progressFill);
        Debug.Log("User Name :" + _userName);
        Debug.Log("Mode :" + _isActive);

        for (int i = 0; i < _slots.Length; i++)
        {
            Debug.Log("Slots :" + _slots[i]);
        }
    }

    public void OnAllDeleteData()
    {
        PlayerPrefs.DeleteAll();
    }

    private void LoadDataByDefould()
    {
        _number = 10;
        _progressFill = 100f;

        _userName = "User";
        _isActive = true;

        for (int i = 0; i < _slots.Length; i++)
        {
            _slots[i] = 0;
        }
    }
}
