using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
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
            _new.Init(item.Icon,item.Prices);
        }
        await Task.Yield();
    }
}
