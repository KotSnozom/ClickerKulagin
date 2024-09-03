using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class AchivmentPrefab : MonoBehaviour
{
    [SerializeField] private string _saveName;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _clik;
    [SerializeField] private Text _text;
    [SerializeField] private int _coinGive;
    [SerializeField] private int _coinBalance;
    [SerializeField] private bool _isGive;
    public void SetAchivment(Sprite sprite,string text,int coin,int coinBalance,string SaveName)
    {
        _icon.sprite = sprite;
        _text.text = text;
        _coinGive = coin;
        _coinBalance = coinBalance;
        _saveName = SaveName;
        LoadAchivment();
        SetInteract(_isGive);
    }

    public void SetInteract(bool IsGive)
    {
        _isGive = IsGive;
        _clik.interactable = !_isGive;
    }

    public void AddCoinPlayer()
    {
        if (GameManager.GetCoin() >= _coinBalance)
        {
            GameManager.OnAddAchivment?.Invoke(_coinGive);
            _clik.interactable = false;
            _isGive = true;
            SaveAchivment();
        }
    }

    private async void SaveAchivment()
    {
        PlayerPrefs.SetInt(_saveName, Convert.ToInt32(_isGive));
        Debug.Log("Сохранение");
        await Task.Yield();
    }
    private async void LoadAchivment()
    {
        _isGive = Convert.ToBoolean(PlayerPrefs.GetInt(_saveName));
        Debug.Log($"Загрузка {_isGive}");
        await Task.Yield();
    }
}
