using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour
{
    [Tooltip("�Ռ��g���^����_���[�W")]
    [SerializeField] private int _damage;

    private readonly string _flameTag = "Flame";
    private readonly string _snowTag = "Snow";
    private readonly string _crabTag = "Crab";

    void Start()
    {
       
    }

    //���������I�u�W�F�N�g�̃^�O���擾���āA���ꂪ�Ή����Ă���^�O�Ȃ炻�̓G�̗̑͂̃X�N���v�g�Ƀ_���[�W��^����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if (collision.CompareTag(_flameTag) ||
            collision.CompareTag(_snowTag)  ||
            collision.CompareTag(_crabTag))
        {
            collision.gameObject.GetComponent<IDamage>().Damage();
            //��ŃJ�j�̏�ԕω��̏�����ǉ�����
        }
    }
}
