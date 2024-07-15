using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class AudioFraza
{
    public AudioClip[] _listAudio;
}
public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _click;
    [SerializeField] private AudioFraza[] _listFraz;
    public static UnityAction<AudioFraza> OnFraza;
    private void Start()
    {
        GameManager.OnUpdateCoin += AddCoin;
        OnFraza += PlayFraza;
    }
    private void AddCoin()
    {
        int _indexR = Random.Range(0,_click.Length);
        _audioSource.clip = _click[_indexR];
        _audioSource.Play();
    }
    private void PlayFraza(AudioFraza list)
    {
        var _myList = list;
        int _rand = Random.Range(0,_myList._listAudio.Length);
        AudioSource.PlayClipAtPoint(_myList._listAudio[_rand],transform.position);
    }
}
