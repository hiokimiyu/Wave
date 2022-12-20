using UnityEngine;

public class AttackStatus : MonoBehaviour
{
    /// <summary> �U���̋��� </summary>
    protected AttackStrength _strength = AttackStrength.Normal;
    /// <summary> �U���̎�� </summary>
    private AttackType _type = AttackType.Cold;

    public AttackStrength Strength { get => _strength; set => _strength = value; }
    public AttackType Type { get => _type; set => _type = value; }


    /// <summary>
    /// �U���̐؂�ւ�
    /// PlayerShot -> Update -> if(.....("Fire2")) �̕����ŌĂяo��
    /// UI�̕\��(���݂̏�Ԃ��������邽��)
    /// </summary>
    public void AttackSwitch()
    {
        Debug.Log("Attack type switch");
        switch (_strength)
        {
            //���݂̏�Ԃɂ���Đ؂�ւ���(���Ԃ�)
            //UI�\���̏���������
            case AttackStrength.Normal:
                _strength = AttackStrength.Middle;
                //AttackType = "������Ƌ���";
                break;
            case AttackStrength.Middle:
                _strength = AttackStrength.PowerAttack;
                //AttackType = "�Ռ��g";
                break;
            case AttackStrength.PowerAttack:
                _strength = AttackStrength.Normal;
                //AttackType = "���g(����)";
                break;
        }
    }

    /// <summary> �U���̋��� </summary>
    public enum AttackStrength
    {
        /// <summary> ���g(�ʏ�) </summary>
        Normal,
        /// <summary> ������Ƌ��� </summary>
        Middle,
        /// <summary> �Ռ��g </summary>
        PowerAttack,
    }

    /// <summary> �U���̎��(���g) </summary>
    public enum AttackType
    {
        /// <summary> ���g </summary>
        Cold,
        /// <summary> �M�g </summary>
        Warm,
    }
}
