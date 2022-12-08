using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���g�A�M�g��؂�ւ���
/// </summary>
public class SwitchWave : MonoBehaviour
{
    private readonly string _enterTag = "Player";
    private AttackStatus _status;

    void Switch()
    {
        //�؂�ւ��I�u�W�F�N�g�ɐG�ꂽ���Ɋ��g�A�M�g��؂�ւ���
        if (_status.Type == AttackStatus.AttackType.Cold)
        {
            _status.Type = AttackStatus.AttackType.Warm;
        }
        else
        {
            _status.Type = AttackStatus.AttackType.Cold;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("�؂�ւ��܂�");
        //�؂�ւ��I�u�W�F�N�g�ɓ����Ă����̂�Player��������
        if (col.CompareTag(_enterTag))
        {
            //���g�A�M�g��؂�ւ���
            Switch();
        }
    }
}
