using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static UnityAction OnAddCoin;
    public static UnityAction<int> OnAddAchivment;
    [SerializeField] private static int _coin;
    [SerializeField] private int _forceAddCoin;

    private const string _progress = "Progress";

    private void Start()
    {
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
        OnAddCoin?.Invoke();
    }
    public void AddCoin()
    {
        _coin += _forceAddCoin;
        OnAddCoin?.Invoke();
    }

    public static int GetCoin() 
    {
        return _coin;
    }

    private async void SaveProgress()
    {
        PlayerPrefs.SetInt(_progress, _coin);
        await Task.Yield();
    }
    private async void LoadProgress()
    {
        if (PlayerPrefs.HasKey(_progress))
        {
            Debug.Log(PlayerPrefs.GetInt(_progress));
            _coin = PlayerPrefs.GetInt(_progress);
        }
        await Task.Delay(1000);
        OnAddCoin?.Invoke();
    }
}
