using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ShopCardPrefab : MonoBehaviour
{
    [SerializeField] private Button _card;
    [SerializeField] private Image Icon;
    [SerializeField] private Text _priceText;

    [SerializeField] private int _addForce;
    [SerializeField] private List<int> _prices;
    [SerializeField] private int _indexPrice;
    public void Init(Sprite icon,List<int> prices)
    {
        Icon.sprite = icon;
        _prices.AddRange(prices);
        _priceText.text = _prices[_indexPrice].ToString();
        ShopManager.OnCheckPrice += CheckPriceCard;
    }
    public void Buy()
    {
        if (_indexPrice < _prices.Count)
        {
            _indexPrice++;
            _indexPrice = Mathf.Clamp(_indexPrice, 0, _prices.Count -1);
            _priceText.text = _prices[_indexPrice].ToString();
            GameManager.OnShopCoin?.Invoke(_prices[_indexPrice],_addForce);
            CheckPriceCard();
        }

    }

    private async void CheckPriceCard()
    {
        int _currentPrice = GameManager.GetCoin();
        if(_currentPrice >= _prices[_indexPrice])
        {
            _card.interactable = true;
        }
        else _card.interactable = false;
        await Task.Yield();
    }
}
