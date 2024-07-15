using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewChopList")]
public class ShopCardList : ScriptableObject
{
    [SerializeField] private List<ShopCard> _shopCards;
    public IEnumerable<ShopCard> ShopCards => _shopCards; 
}
