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

    [SerializeField] private List<int> _prices;
    [SerializeField] private int _indexPrice;
    public void Init(Sprite icon,List<int> prices)
    {
        Icon.sprite = icon;
        _prices.AddRange(prices);
        _priceText.text = _prices[_indexPrice].ToString();
    }
}
