using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    #region Action Button
    public static Action clickButtonSaveData;
    public static Action clickButtonLoadData;
    public static Action clickButtonDeleteData;
    #endregion

    #region UI Button
    [Header("Button UI")]
    [SerializeField] private Button _buttonSaveData;
    [SerializeField] private Button _buttonLoadData;
    [SerializeField] private Button _butonDeleteData;
    #endregion

    private void Start()
    {
        AddAllListener();
    }

    private void AddAllListener()
    {
        _buttonSaveData.onClick.RemoveAllListeners();
        _buttonSaveData.onClick.AddListener(OnSaveDataButtonClick);

        _buttonLoadData.onClick.RemoveAllListeners();
        _buttonLoadData.onClick.AddListener(OnLoadDataButtonClick);

        _butonDeleteData.onClick.RemoveAllListeners();
        _butonDeleteData.onClick.AddListener(OnDeleteDataButtonClick);
    }

    #region Methods Button Click
    private void OnSaveDataButtonClick()
    {
        clickButtonSaveData?.Invoke();
    }
    private void OnLoadDataButtonClick()
    {
        clickButtonLoadData?.Invoke();
    }
    private void OnDeleteDataButtonClick()
    {
        clickButtonDeleteData?.Invoke();
    }
    #endregion
}
