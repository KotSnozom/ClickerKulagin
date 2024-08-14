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

    private async void Start()
    {
        await SpawnAchivment();
        LoadAchivment();
    }
    private void OnApplicationQuit()
    {
        SaveAchivment();
    }
    private async Task SpawnAchivment()
    {
        foreach (var item in achivmentList.Achivments)
        {
            AchivmentPrefab _new = Instantiate(_achivmentPrefab,_parent);
            _new.SetAchivment(item.Icon,item.Text,item.CoinGive,item.CoinsBalance,item.SaveName);
            achivmentPrefabs.Add(_new);
        }
        await Task.Yield();
    }
    private async void SaveAchivment()
    {
        foreach (var item in achivmentPrefabs)
        {
            PlayerPrefs.SetInt(item.SaveName,Convert.ToInt32(item.IsGive));
            Debug.Log(Convert.ToInt32(item.IsGive));
        }
        await Task.Yield();
    }
    private async void LoadAchivment()
    {
        foreach (var item in achivmentPrefabs)
        {
            int _state = PlayerPrefs.GetInt(item.SaveName);
            Debug.Log(PlayerPrefs.GetInt(item.SaveName));
            item.SetInteract(Convert.ToBoolean(_state));
            Debug.Log(Convert.ToBoolean(_state));
        }
        await Task.Yield();
    }
}