using Consts;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �Q�[���V�[�����UI�𓝊�����
/// </summary>
public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider _playerHPBar;
    [SerializeField] private Slider _vitalCapacityBar;
    [SerializeField] private Text _attackTypeText;

    /// <summary> ���݂̍U����� </summary>
    private readonly string _attackType = "���g";
    private int _playerHP;
    private float _playerVital;
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag(Constants.PLAYER_TAG);

        _playerHP = _player.GetComponent<PlayerMove>().PlayerHP;
        _playerVital = _player.GetComponent<VitalCapacity>().CurrentVital;

        //Slider�̏����ݒ�(�����l�͍ő�l�ɐݒ�)
        _playerHPBar.maxValue = _playerHP;
        _vitalCapacityBar.value = _playerHP;

        _vitalCapacityBar.maxValue = _playerVital;
        _vitalCapacityBar.value = _playerVital;
    }

    private void Update()
    {
        //UI�̔��f
        _attackTypeText.text = _attackType;

        _playerHPBar.value = _playerHP;
        _vitalCapacityBar.value = _playerVital;
    }
}
