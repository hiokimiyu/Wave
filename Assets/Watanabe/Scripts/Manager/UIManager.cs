using Consts;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ゲームシーン上のUIを統括する
/// </summary>
public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider _playerHPBar;
    [SerializeField] private Slider _vitalCapacityBar;
    [SerializeField] private Text _attackTypeText;

    /// <summary> 現在の攻撃状態 </summary>
    private readonly string _attackType = "音波";
    private int _playerHP;
    private float _playerVital;
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag(Constants.PLAYER_TAG);

        _playerHP = _player.GetComponent<PlayerMove>().PlayerHP;
        _playerVital = _player.GetComponent<VitalCapacity>().CurrentVital;

        //Sliderの初期設定(初期値は最大値に設定)
        _playerHPBar.maxValue = _playerHP;
        _vitalCapacityBar.value = _playerHP;

        _vitalCapacityBar.maxValue = _playerVital;
        _vitalCapacityBar.value = _playerVital;
    }

    private void Update()
    {
        //UIの反映
        _attackTypeText.text = _attackType;

        _playerHPBar.value = _playerHP;
        _vitalCapacityBar.value = _playerVital;
    }
}
