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

    /// <summary> ���g���A�M�g��(false...���g, true...�M�g) </summary>
    public bool IsWarm { get; set; }

    void Switch()
    {
        //�؂�ւ��I�u�W�F�N�g�ɐG�ꂽ���Ɋ��g�A�M�g��؂�ւ���
        //���g�A�M�g�̐؂�ւ�(false...���g, true...�M�g)
        IsWarm = IsWarm == true ? false : true;
        Debug.Log(IsWarm);
        //player�ɁA���݂̍U���̏�Ԃ�ۑ����Ă����ϐ���p�ӂ��Ă��炤
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
