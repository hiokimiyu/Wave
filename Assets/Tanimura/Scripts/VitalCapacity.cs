using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VitalCapacity : MonoBehaviour
{
    [Tooltip("肺活量の最大値")]
    [SerializeField] float _maxVitalCapacity;
    [Tooltip("現在の肺活量")]
    [SerializeField] float _vitalCapacity;
    [Tooltip("肺活量の回復量")]
    [SerializeField] float _recoveryAmount;
    [Tooltip("肺活量バー")]
    [SerializeField] Slider _vitalCapacityBar;
    /// <summary>回復できるかどうかの判定</summary>
    bool _isRecovery;
    /// <summary>回復できるかどうかの判定のプロパティ</summary>
    public bool IsRecovery{ get => _isRecovery; set => _isRecovery = value; }


void Start()
    {
        //肺活量とMax肺活量の設定
        _vitalCapacityBar.maxValue = _maxVitalCapacity;
        _vitalCapacityBar.value = _vitalCapacity;
    }

    void Update()
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
    
    /// <summary>肺活量を回復アイテムで回復するときの関数</summary>
    /// <param name="heal"></param>
    public void VitalCapacityHeal(int heal)
    {
        _vitalCapacity += heal;
        if(_vitalCapacity > _maxVitalCapacity)
        {
            _vitalCapacity = _maxVitalCapacity;
        }
    }

    /// <summary>攻撃を出すときに肺活量が足りていたらtrue,足りていなかったらfalseを返す</summary>
    /// <param name="use"></param>
    /// <returns></returns>
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
