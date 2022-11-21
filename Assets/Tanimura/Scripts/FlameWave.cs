using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameWave : MonoBehaviour
{
    [Tooltip("��̃^�O")]
    [SerializeField, TagName] string _SnowTag;
    [Tooltip("�Ռ��g���^����_���[�W")]
    [SerializeField] int _damage;
    TestEnemyHp _colObjScript;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    //���������I�u�W�F�N�g�̃^�O���擾���āA���ꂪ�Ⴞ�������Ƀ_���[�W��^����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        string colObj = collision.gameObject.tag;
        if (collision.tag == _SnowTag)//
        {
            Debug.Log(colObj);
            _colObjScript = collision.gameObject.GetComponent<TestEnemyHp>();
            _colObjScript.Damage(_damage);
        }
    }
}
