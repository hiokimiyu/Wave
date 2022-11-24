using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���g�A�M�g��؂�ւ���
/// </summary>
public class SwitchWave : MonoBehaviour
{
    [Tooltip("�؂�ւ��I�u�W�F�N�g�ɓ����Ă����̂�Player���ǂ���")]
    [SerializeField, TagName] string _enterTag;
    [Tooltip("GameManager(�؂�ւ��p)")]
    [SerializeField] GameManager _manager;

    void Switch()
    {
        //�؂�ւ��I�u�W�F�N�g�ɐG�ꂽ���Ɋ��g�A�M�g��؂�ւ���
        if (_manager.Type == GameManager.AttackType.Cold)
        {
            _manager.Type = GameManager.AttackType.Warm;
        }
        else
        {
            _manager.Type = GameManager.AttackType.Cold;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("�؂�ւ��܂�");
        //�؂�ւ��I�u�W�F�N�g�ɓ����Ă����̂�Player��������
        if (col.tag == _enterTag)
        {
            //���g�A�M�g��؂�ւ���
            Switch();
        }
    }
}
