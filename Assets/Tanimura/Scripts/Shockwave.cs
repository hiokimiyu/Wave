using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour
{
    [Tooltip("���̃^�O")]
    [SerializeField, TagName] string _flameTag;
    [Tooltip("��̃^�O")]
    [SerializeField, TagName] string _snowTag;
    [Tooltip("�J�j�̃^�O")]
    [SerializeField, TagName] string _clabTag;
    [Tooltip("�Ռ��g���^����_���[�W")]
    [SerializeField] int _damage;
    [SerializeField] GameObject _player;

�@�@
    void Start()
    {
       
    }

    //���������I�u�W�F�N�g�̃^�O���擾���āA���ꂪ�Ή����Ă���^�O�Ȃ炻�̓G�̗̑͂̃X�N���v�g�Ƀ_���[�W��^����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if (collision.tag == _flameTag || collision.tag == _snowTag || collision.tag == _clabTag)
        {
            collision.gameObject.GetComponent<IDamage>().Damage();
            //��ŃJ�j�̏�ԕω��̏�����ǉ�����
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
