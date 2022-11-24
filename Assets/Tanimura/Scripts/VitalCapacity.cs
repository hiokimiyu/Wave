using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VitalCapacity : MonoBehaviour
{
    [Tooltip("�x���ʂ̍ő�l")]
    [SerializeField] float _maxVitalCapacity;
    [Tooltip("���݂̔x����")]
    [SerializeField] float _vitalCapacity;
    [Tooltip("�x���ʂ̉񕜗�")]
    [SerializeField] float _recoveryAmount;
    [Tooltip("�x���ʃo�[")]
    [SerializeField] Slider _vitalCapacityBar;
    /// <summary>�񕜂ł��邩�ǂ����̔���</summary>
    bool _isRecovery = true;
    /// <summary>�񕜂ł��邩�ǂ����̔���̃v���p�e�B</summary>
    public bool IsRecovery{ get => _isRecovery; set => _isRecovery = value; }


void Start()
    {
        //�x���ʂ�Max�x���ʂ̐ݒ�
        _vitalCapacityBar.maxValue = _maxVitalCapacity;
        _vitalCapacityBar.value = _vitalCapacity;
    }

    void Update()
    {
        _vitalCapacityBar.value = _vitalCapacity;
        //�񕜏�ԂɂȂ�����x���ʂ��񕜂���
        if (_isRecovery)
        {
            _vitalCapacity += _recoveryAmount;
            //�ő�l�ȏ�ɂȂ�Ȃ��悤�ɂ��鏈��
            if (_vitalCapacity > _maxVitalCapacity)
            {
                _vitalCapacity = _maxVitalCapacity;
            }
        }


    }
    
    /// <summary>�x���ʂ��񕜃A�C�e���ŉ񕜂���Ƃ��̊֐�</summary>
    /// <param name="heal"></param>
    public void VitalCapacityHeal(int heal)
    {
        _vitalCapacity += heal;
        if(_vitalCapacity > _maxVitalCapacity)
        {
            _vitalCapacity = _maxVitalCapacity;
        }
    }

    /// <summary>�U�����o���Ƃ��ɔx���ʂ�����Ă�����true,����Ă��Ȃ�������false��Ԃ�</summary>
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
