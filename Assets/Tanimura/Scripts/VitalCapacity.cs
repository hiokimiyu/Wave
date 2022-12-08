using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VitalCapacity : MonoBehaviour
{
    [Header("�x����")]
    [Tooltip("���݂̔x����")]
    [SerializeField] private float _vitalCapacity;
    [Tooltip("�ő�l")]
    [SerializeField] private float _maxVitalCapacity;
    [Tooltip("�񕜗�")]
    [SerializeField] private float _recoveryAmount;
    [Tooltip("�o�[")]
    [SerializeField] private Slider _vitalCapacityBar;

    /// <summary>�񕜂ł��邩�ǂ����̔���</summary>
    private bool _isRecovery = true;

    /// <summary>�񕜂ł��邩�ǂ����̔���̃v���p�e�B</summary>
    public bool IsRecovery { get => _isRecovery; set => _isRecovery = value; }


    private void Start()
    {
        //�x���ʂ�Max�x���ʂ̐ݒ�
        _vitalCapacityBar.maxValue = _maxVitalCapacity;
        _vitalCapacityBar.value = _vitalCapacity;
    }

    private void Update()
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
    
    /// <summary> �x���ʂ��񕜃A�C�e���ŉ񕜂���Ƃ��̊֐� </summary>
    //public void VitalCapacityHeal(int heal)
    //{
    //    _vitalCapacity += heal;
    //    if(_vitalCapacity > _maxVitalCapacity)
    //    {
    //        _vitalCapacity = _maxVitalCapacity;
    //    }
    //}

    /// <summary> �U�����o���Ƃ��ɔx���ʂ�����Ă�����true
    ///           ����Ă��Ȃ�������false��Ԃ� </summary>
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
