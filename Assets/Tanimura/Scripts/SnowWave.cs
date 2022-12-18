using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowWave : MonoBehaviour
{
    [Tooltip("�Ռ��g���^����_���[�W")]
    [SerializeField] private int _damage;

    private readonly string _flameTag = "Flame";
    private float _lifeTime = 0.5f;

    void Update()
    {
        //�M�g����莞�Ԃ�����������鏈��
        _lifeTime -= Time.deltaTime;
        if (_lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    //���������I�u�W�F�N�g�̃^�O���擾���āA���ꂪ�Ⴞ�������Ƀ_���[�W��^����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if (collision.CompareTag(_flameTag))
        {
            collision.gameObject.GetComponent<IDamage>().Damage();
        }
    }
}
