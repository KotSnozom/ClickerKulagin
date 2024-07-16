using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class ShopManager : MonoBehaviour
{
    public static UnityAction OnCheckPrice;
    [SerializeField] private RectTransform _parent;
    [SerializeField] private ShopCardList _shopCardList;
    [SerializeField] private ShopCardPrefab _cardPrefab;

    private void Start()
    {
        ShopInit();
    }
    private async void ShopInit()
    {
        foreach (var item in _shopCardList.ShopCards)
        {
            ShopCardPrefab _new = Instantiate(_cardPrefab,_parent);
            _new.Init(item.NameCard,item.Icon,item.Prices);
        }
        CheckPriceCard();
        await Task.Yield();
    }
    public static void CheckPriceCard()
    {
        OnCheckPrice?.Invoke();
    }
}
