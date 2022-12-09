using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ゲームシーン上のUIを統括する
/// </summary>
public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider _playerHPBar;
    [SerializeField] private Slider _vitalCapacityBar;

    private GameObject _player;
    private int _playerHP;
    private float _playerVital;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("TestPlayer");

        _playerHP = _player.GetComponent<PlayerMove>().PlayerHP;
        _playerVital = _player.GetComponent<VitalCapacity>().CurrentVital;

        //Sliderの初期設定(初期値は最大値)
        _playerHPBar.maxValue = _playerHP;
        _vitalCapacityBar.value = _playerHP;

        _vitalCapacityBar.maxValue = _playerVital;
        _vitalCapacityBar.value = _playerVital;
    }

    // Update is called once per frame
    void Update()
    {
        _playerHPBar.value = _playerHP;
        _vitalCapacityBar.value = _playerVital;
    }
}
