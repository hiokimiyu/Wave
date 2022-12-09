using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �Q�[���V�[�����UI�𓝊�����
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

        //Slider�̏����ݒ�(�����l�͍ő�l)
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
