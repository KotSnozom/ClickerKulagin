using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchivmentPrefab : MonoBehaviour
{
    [SerializeField] private string _saveName;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _clik;
    [SerializeField] private Text _achivText;
    [SerializeField] private Text _addText;
    [SerializeField] private int _coinGive;
    [SerializeField] private int _coinBalance;
    [SerializeField] private bool _isGive;

    public bool IsGive => _isGive;
    public string SaveName => _saveName;
    public void SetAchivment(Sprite sprite,string text,int coin,int coinBalance,string SaveName)
    {
        _icon.sprite = sprite;
        _achivText.text = text;
        _addText.text = $"{coinBalance} +{coin}";
        _coinGive = coin;
        _coinBalance = coinBalance;
        _saveName = SaveName;

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
        }
    }
}
