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

    private GameObject _player;
    private int _playerHP;
    private float _playerVital;
    /// <summary> 現在の攻撃状態 </summary>
    private readonly string _attackType = "音波";

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
        _attackTypeText.text = _attackType;

        _playerHPBar.value = _playerHP;
        _vitalCapacityBar.value = _playerVital;
    }
}
