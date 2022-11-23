using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    [Tooltip("���������I�u�W�F�N�g�̂̃^�O")]
    [SerializeField, TagName] string _hitTag;
    [Tooltip("�Ռ��g���^����_���[�W")]
    [SerializeField] int _damage;
    float _lifeTime = 0.5f;
    TestEnemyHp _colObjHp;

    // Update is called once per frame
    void Update()
    {
        //�M�g����莞�Ԃ�����������鏈��
        _lifeTime -= Time.deltaTime;
        if (_lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == _hitTag)
        {
            _colObjHp = collision.gameObject.GetComponent<TestEnemyHp>();
            _colObjHp.Damage(_damage);
        }
    }
}
