using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

[System.Serializable]
public class WindowType
{
    public GameObject Panel;
    public Toggle Toggle;
}

public class UIManager : MonoBehaviour
{
    [SerializeField] private Camera _cam;

    [SerializeField] private Text _coinText;
    [SerializeField] private ToggleGroup _toggleGroup;
    [SerializeField] private List<WindowType> _windowTypes;

    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private ParticleSystem _BGParticleS;

    private void Start()
    {
        GameManager.OnUpdateCoin += CoinUpdate;
        SetBounceBGParticle();
    }
    private void CoinUpdate()
    {
        _coinText.text = GameManager.GetCoin().ToString();
        Debug.Log("—чет обнавлен");
    }

    public void TypeWindow(bool This)
    {
        Toggle _myTggle = _toggleGroup.ActiveToggles().FirstOrDefault();

        if (This)
        {
            Debug.Log(_myTggle.name);
            foreach (var item1 in _windowTypes)
            {
                item1.Panel.SetActive(false);
            }

            foreach (var item in _windowTypes)
            {
                if (_myTggle == item.Toggle)
                {
                    item.Panel.SetActive(true);
                }
            }
        }
    }

    public void Partical()
    {
        Vector3 _parPos = _cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,0.5f));
        _particleSystem.transform.position = _parPos;

        _particleSystem.Play();
    }

    private void SetBounceBGParticle()
    {
        var _particle = _BGParticleS.shape;
        _particle.scale = _cam.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0)) * 2;
    }
}
