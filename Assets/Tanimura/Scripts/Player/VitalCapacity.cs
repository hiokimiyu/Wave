using UnityEngine;

/// <summary>
/// �x���ʂɂ��U���̃N���X
/// </summary>
public class VitalCapacity : MonoBehaviour
{
    [Header("�x����")]
    [Tooltip("�ő�l")]
    [SerializeField] private float _maxVitalCapacity;
    [Tooltip("�񕜗�")]
    [SerializeField] private float _recoveryAmount;

    /// <summary> ���݂̔x���� </summary>
    private float _currentVital;
    /// <summary>�񕜂ł��邩�ǂ����̔���</summary>
    private bool _isRecovery;

    /// <summary> ���݂̔x���� </summary>
    public float CurrentVital { get => _currentVital; set => _currentVital = value; }
    /// <summary>�񕜂ł��邩�ǂ����̔���̃v���p�e�B</summary>
    public bool IsRecovery { get => _isRecovery; set => _isRecovery = value; }


    private void Awake()
    {
        //�����l�ɍő�l��ݒ�
        _currentVital = _maxVitalCapacity;
    }

    private void Update()
    {
        //�񕜏�ԂɂȂ�����x���ʂ��񕜂���
        if (_isRecovery)
        {
            _currentVital += _recoveryAmount;

            //�ő�l�ȏ�ɂȂ�Ȃ��悤�ɂ��鏈��
            if (_currentVital >= _maxVitalCapacity)
            {
                _currentVital = _maxVitalCapacity;
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
        if (_currentVital >= use)
        {
            _currentVital -= use;
            return true;
        }
        return false;
    }
}