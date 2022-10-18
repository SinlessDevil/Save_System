using UnityEngine;

public class TestSavingPlayerPrefs : MonoBehaviour
{
    #region Data Variabls
    [Header("Variabls")]
    [Range(1, 10)] [SerializeField] private int _number = 0;
    [Range(1, 100)] [SerializeField] private float _progressFill = 0.0f;
    [SerializeField] private string _userName = "User";
    [SerializeField] private bool _isActive = false;
    [Space(10)]
    [Header("Array Variabls")]
    [Range(1, 10)] [SerializeField] private int[] _numbers = new int[10];
    [Range(1, 100)] [SerializeField] private float[] _progressFills = new float[8];
    [SerializeField] private string[] _usersNames = new string[5];
    [SerializeField] private bool[] _isActives = new bool[4];
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

        PlayerPrefsManager.instance.SaveArrayIntData(DictionarySaveKey.nameKeyArrayNumbers, _numbers);
        PlayerPrefsManager.instance.SaveArrayFloatData(DictionarySaveKey.nameKeyArrayProgresses, _progressFills);
        PlayerPrefsManager.instance.SaveArrayStringData(DictionarySaveKey.nameKeyArrayNames, _usersNames);
        PlayerPrefsManager.instance.SaveArrayBoolData(DictionarySaveKey.nameKeyArrayModes, _isActives);
        Debug.Log("Saving ... ");
    }

    public void OnLoadData()
    {
        _number = PlayerPrefsManager.instance.LoadIntData(DictionarySaveKey.nameKeyNumber, _number);
        _progressFill = PlayerPrefsManager.instance.LoadFloatData(DictionarySaveKey.nameKeyProgress, _progressFill);
        _userName = PlayerPrefsManager.instance.LoadStringData(DictionarySaveKey.nameKeyName, _userName);
        _isActive = PlayerPrefsManager.instance.LoadBoolData(DictionarySaveKey.nameKeyMode, _isActive);

        _numbers = PlayerPrefsManager.instance.LoadArrayIntData(DictionarySaveKey.nameKeyArrayNumbers, _numbers);
        _progressFills = PlayerPrefsManager.instance.LoadArrayFloatData(DictionarySaveKey.nameKeyArrayProgresses, _progressFills);
        _usersNames = PlayerPrefsManager.instance.LoadArrayStringData(DictionarySaveKey.nameKeyArrayNames, _usersNames);
        _isActives = PlayerPrefsManager.instance.LoadArrayBoolData(DictionarySaveKey.nameKeyArrayModes, _isActives);

        Debug.Log("Loading ... ");
    }

    public void OnAllDeleteData()
    {
        // PlayerPrefs.DeleteAll();
        LoadDataByDefould();
    }

    private void LoadDataByDefould()
    {
        _number = 10;
        _progressFill = 100f;

        _userName = "User";
        _isActive = true;

        for (int i = 0; i < _numbers.Length; i++)
            _numbers[i] = 10;
        for (int i = 0; i < _progressFills.Length; i++)
            _progressFills[i] = 100f;
        for (int i = 0; i < _usersNames.Length; i++)
            _usersNames[i] = "User";
        for (int i = 0; i < _isActives.Length; i++)
            _isActives[i] = true;
    }
}
