using Consts;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ƒQ[ƒ€ƒV[ƒ“ã‚ÌUI‚ğ“Š‡‚·‚é
/// </summary>
public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider _playerHPBar;
    [SerializeField] private Slider _vitalCapacityBar;
    [SerializeField] private Text _attackTypeText;

    /// <summary> Œ»İ‚ÌUŒ‚ó‘Ô </summary>
    private readonly string _attackType = "‰¹”g";
    private int _playerHP;
    private float _playerVital;
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag(Constants.PLAYER_TAG);

        _playerHP = _player.GetComponent<PlayerMove>().PlayerHP;
        _playerVital = _player.GetComponent<VitalCapacity>().CurrentVital;

        //Slider‚Ì‰Šúİ’è(‰Šú’l‚ÍÅ‘å’l‚Éİ’è)
        _playerHPBar.maxValue = _playerHP;
        _vitalCapacityBar.value = _playerHP;

        _vitalCapacityBar.maxValue = _playerVital;
        _vitalCapacityBar.value = _playerVital;
    }

    private void Update()
    {
        //UI‚Ì”½‰f
        _attackTypeText.text = _attackType;

        _playerHPBar.value = _playerHP;
        _vitalCapacityBar.value = _playerVital;
    }
}
