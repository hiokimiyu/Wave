using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowWave : MonoBehaviour
{
    [Tooltip("���̃^�O")]
    [SerializeField, TagName] string _flameTag;
    [Tooltip("�Ռ��g���^����_���[�W")]
    [SerializeField] int _damage;
    float _lifeTime = 0.5f;
    TestEnemyHp _colObjHp;
    

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
        string colObj = collision.gameObject.tag;//�ϐ�����Ȃ��Ă���
        if (collision.tag == _flameTag)
        {
            collision.gameObject.GetComponent<IDamage>().Damage();
        }
    }
}
