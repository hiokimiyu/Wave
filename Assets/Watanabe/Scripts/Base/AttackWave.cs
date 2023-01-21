using System.Collections.Generic;
using UnityEngine;

public class AttackWave : MonoBehaviour
{
    [Tooltip("�Ռ��g���^����_���[�W")]
    [SerializeField] private int _damage = 1;
    [Tooltip("����p��Tag")]
    [SerializeField] private List<string> _hitTag = new();

    private float _lifeTime = 0.5f;

    private void Update()
    {
        //�M�g����莞�Ԃ�����������鏈��
        _lifeTime -= Time.deltaTime;
        if (_lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    //���������I�u�W�F�N�g�̃^�O���擾���āA���ꂪ��(��)���������Ƀ_���[�W��^����
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log($"Hit {col.tag}");
        if (_hitTag.IndexOf(col.tag) >= 0)
        {
            col.gameObject.GetComponent<IDamage>().Damage();
        }
    }
}
