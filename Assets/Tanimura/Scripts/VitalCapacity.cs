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

    /// <summary> 現在の肺活量 </summary>
    private float _currentVital;
    /// <summary>回復できるかどうかの判定</summary>
    private bool _isRecovery;

    /// <summary> 現在の肺活量 </summary>
    public float CurrentVital { get => _currentVital; set => _currentVital = value; }
    /// <summary>回復できるかどうかの判定のプロパティ</summary>
    public bool IsRecovery { get => _isRecovery; set => _isRecovery = value; }


    private void Awake()
    {
        //初期値に最大値を設定
        _currentVital = _maxVitalCapacity;
    }

    private void Update()
    {
        //回復状態になったら肺活量を回復する
        if (_isRecovery)
        {
            _currentVital += _recoveryAmount;

            //最大値以上にならないようにする処理
            if (_currentVital >= _maxVitalCapacity)
            {
                _currentVital = _maxVitalCapacity;
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
        if (_currentVital >= use)
        {
            _currentVital -= use;
            return true;
        }
        return false;
    }
}
