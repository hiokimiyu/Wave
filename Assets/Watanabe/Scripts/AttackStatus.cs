using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStatus : MonoBehaviour
{
    /// <summary> �U���̋��� </summary>
    AttackStrength _strength = AttackStrength.Normal;
    /// <summary> �U���̎�� </summary>
    AttackType _type = AttackType.Cold;

    /// <summary> �U���̋��� </summary>
    public AttackStrength Strength { get => _strength; set => _strength = value; }
    public AttackType Type { get => _type; set => _type = value; }


    /// <summary>
    /// �U���̐؂�ւ�
    /// PlayerShot -> Update -> if(.....("Fire2")) �̕����ŌĂяo��
    /// UI�̕\��(���݂̏�Ԃ��������邽��)
    /// </summary>
    public void AttackSwitch()
    {
        //���݂̏�Ԃɂ���Đ؂�ւ���(���Ԃ�)
        //UI�\���̏���������
        if (Strength == AttackStrength.Normal)
        {
            Strength = AttackStrength.Middle;
            AttackType = "������Ƌ���";
        }
        else if (Strength == AttackStrength.Middle)
        {
            if (Type == AttackType.Cold)
                Type = AttackType.Warm;
            else
                Type = AttackType.Cold;

            Strength = AttackStrength.PowerAttack;
            AttackType = "�Ռ��g";
        }
        else if (Strength == AttackStrength.PowerAttack)
        {
            Strength = AttackStrength.Normal;
            AttackType = "���g(����)";
        }
    }

    /// <summary> �U���̋��� </summary>
    public enum AttackStrength
    {
        /// <summary> ���g(�ʏ�) </summary>
        Normal,
        /// <summary> ������Ƌ������ </summary>
        Middle,
        /// <summary> �Ռ��g </summary>
        PowerAttack,
    }

    /// <summary> �U���̎�� </summary>
    public enum AttackType
    {
        /// <summary> ���g </summary>
        Cold,
        /// <summary> �M�g </summary>
        Warm,
    }
}
