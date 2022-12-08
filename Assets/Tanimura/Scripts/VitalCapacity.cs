using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VitalCapacity : MonoBehaviour
{
    [Header("肺活量")]
    [Tooltip("現在の肺活量")]
    [SerializeField] private float _vitalCapacity;
    [Tooltip("最大値")]
    [SerializeField] private float _maxVitalCapacity;
    [Tooltip("回復量")]
    [SerializeField] private float _recoveryAmount;
    [Tooltip("バー")]
    [SerializeField] private Slider _vitalCapacityBar;

    /// <summary>回復できるかどうかの判定</summary>
    private bool _isRecovery = true;

    /// <summary>回復できるかどうかの判定のプロパティ</summary>
    public bool IsRecovery { get => _isRecovery; set => _isRecovery = value; }


    private void Start()
    {
        //肺活量とMax肺活量の設定
        _vitalCapacityBar.maxValue = _maxVitalCapacity;
        _vitalCapacityBar.value = _vitalCapacity;
    }

    private void Update()
    {
        _vitalCapacityBar.value = _vitalCapacity;

        //回復状態になったら肺活量を回復する
        if (_isRecovery)
        {
            _vitalCapacity += _recoveryAmount;

            //最大値以上にならないようにする処理
            if (_vitalCapacity > _maxVitalCapacity)
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
        if(_vitalCapacity < use)
        {
            return false;
        }
        else
        {
            _vitalCapacity -= use;
            return true;
        }
    }
}
