using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static UnityAction<int,int> OnShopCoin;
    public static UnityAction OnUpdateCoin;
    public static UnityAction<int> OnAddAchivment;

    [SerializeField] private static int _coin;
    [SerializeField] private int _forceAddCoin;

    private const string _force = "ForceTap";
    private const string _progress = "Progress";

    private void Start()
    {
        OnShopCoin += MinusCoin;
        OnAddAchivment += AddCoinAchivment;
        LoadProgress();
    }
    private void OnApplicationQuit()
    {
        SaveProgress();
    }
    private void AddCoinAchivment(int coin)
    {
        _coin += coin;
        OnUpdateCoin?.Invoke();
    }
    public void AddCoin()
    {
        _coin += _forceAddCoin;
        OnUpdateCoin?.Invoke();
    }
    public void MinusCoin(int coin,int addForce)
    {
        _forceAddCoin += addForce;
        _coin -= coin;
        OnUpdateCoin?.Invoke();
    }
    public static int GetCoin() 
    {
        return _coin;
    }
    private async void SaveProgress()
    {
        PlayerPrefs.SetInt(_force, _forceAddCoin);
        PlayerPrefs.SetInt(_progress, _coin);
        await Task.Yield();
    }
    private async void LoadProgress()
    {
        if (PlayerPrefs.HasKey(_progress))
        {
            _coin = PlayerPrefs.GetInt(_progress);
        }
        if (PlayerPrefs.HasKey(_force))
        {
            _forceAddCoin = PlayerPrefs.GetInt(_force);
        }
        await Task.Delay(1000);
        OnUpdateCoin?.Invoke();
    }
}
