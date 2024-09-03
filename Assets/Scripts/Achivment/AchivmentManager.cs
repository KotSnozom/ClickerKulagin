using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AchivmentManager : MonoBehaviour
{
    [SerializeField] private AchivmentList achivmentList;
    [SerializeField] private RectTransform _parent;
    [SerializeField] private AchivmentPrefab _achivmentPrefab;
    [SerializeField] private List<AchivmentPrefab> achivmentPrefabs;

    private void Start()
    {
        SpawnAchivment();
    }
    private async void SpawnAchivment()
    {
        foreach (var item in achivmentList.Achivments)
        {
            AchivmentPrefab _new = Instantiate(_achivmentPrefab,_parent);
            _new.SetAchivment(item.Icon,item.Text,item.CoinGive,item.CoinsBalance,item.SaveName);
            achivmentPrefabs.Add(_new);
        }
        await Task.Yield();
    }
}