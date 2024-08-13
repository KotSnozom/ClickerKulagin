using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ShopCardPrefab : MonoBehaviour
{
    private const string MaxLVL = "M.уровень";
    [SerializeField] private Button _card;
    [SerializeField] private Image Icon;
    [SerializeField] private Text _priceText;
    private string _name;

    [SerializeField] private int _addForce;
    [SerializeField] private List<int> _prices;
    [SerializeField] private int _indexPrice;

    private void OnApplicationQuit()
    {
        SaveState();
    }
    public void Init(string Name,Sprite icon,List<int> prices)
    {
        ShopManager.OnCheckPrice += CheckPriceCard;
        _name = Name;
        Icon.sprite = icon;
        _prices.AddRange(prices);
        _priceText.text = _prices[_indexPrice].ToString();
        LoadState();
    }
    public void Buy()
    {
        if (_indexPrice <= _prices.Count)
        {
            GameManager.OnShopCoin?.Invoke(_prices[_indexPrice],_addForce);
            _indexPrice++;
        }
            ShopManager.OnCheckPrice?.Invoke();
    }
    private async void CheckPriceCard()
    {
        await Task.Yield();
        int _currentPrice = GameManager.GetCoin();

        if(_indexPrice < _prices.Count)
        {
            Debug.Log(_indexPrice < _prices.Count);
            _priceText.text = _prices[_indexPrice].ToString();
            if (_currentPrice > _prices[_indexPrice])
            {
                _card.interactable = true;
                _indexPrice = Mathf.Clamp(_indexPrice, 0, _prices.Count);
            }
            else
            {
                _card.interactable = false;
            }
        }

        if(_indexPrice == _prices.Count)
        {
            _card.interactable = false;
            _priceText.text = MaxLVL;
        }

    }
    private async void SaveState()
    {
        PlayerPrefs.SetInt(_name, _indexPrice);
        await Task.Yield();
    }
    private async void LoadState()
    {
        if (PlayerPrefs.HasKey(_name))
        {
            _indexPrice = PlayerPrefs.GetInt(_name);

        }
        await Task.Yield();
    }
}
