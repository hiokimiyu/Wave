using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 肺活量による攻撃のクラス
/// </summary>
public class VitalCapacity : MonoBehaviour
{
    [Header("肺活量")]
    [Tooltip("最大値")]
    [SerializeField] private float _maxVitalCapacity;
    [Tooltip("回復量")]
    [SerializeField] private float _recoveryAmount;
    [Tooltip("バー(UI)")]
    [SerializeField] private Slider _vitalCapacityBar;

    /// <summary> 現在の肺活量 </summary>
    private float _vitalCapacity;
    /// <summary>回復できるかどうかの判定</summary>
    private bool _isRecovery;

    /// <summary>回復できるかどうかの判定のプロパティ</summary>
    public bool IsRecovery { get => _isRecovery; set => _isRecovery = value; }


    private void Start()
    {
        //初期値に最大値を設定
        _vitalCapacity = _maxVitalCapacity;

        //Sliderに値を設定する(初期値は最大値)
        _vitalCapacityBar.maxValue = _maxVitalCapacity;
        _vitalCapacityBar.value = _maxVitalCapacity;
    }

    private void Update()
    {
        _vitalCapacityBar.value = _vitalCapacity;

        //回復状態になったら肺活量を回復する
        if (_isRecovery)
        {
            _vitalCapacity += _recoveryAmount;

            //最大値以上にならないようにする処理
            if (_vitalCapacity >= _maxVitalCapacity)
            {
                _vitalCapacity = _maxVitalCapacity;
            }
        }
    }
    
    /// <summary> 肺活量を回復アイテムで回復するときの関数 </summary>
    //public void VitalCapacityHeal(int heal)
    //{
    //    _vitalCapacity += heal;
    //    if(_vitalCapacity > _maxVitalCapacity)
    //    {
    //        _vitalCapacity = _maxVitalCapacity;
    //    }
    //}

    /// <summary> 攻撃を出すときに肺活量が足りていたらtrue
    ///           足りていなかったらfalseを返す </summary>
    public bool VitalCapacityUse(int use)
    {
        if (_vitalCapacity >= use)
        {
            _vitalCapacity -= use;
            return true;
        }
        return false;
    }
}
