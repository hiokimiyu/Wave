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
    TestEnemyHp _colObjHp;
    Kani _colKaniScript;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //���������I�u�W�F�N�g�̃^�O���擾���āA���ꂪ�Ή����Ă���^�O�Ȃ炻�̓G�̗̑͂̃X�N���v�g�Ƀ_���[�W��^����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        string colObj = collision.gameObject.tag;
        if (collision.tag == _flameTag || collision.tag == _snowTag)
        {
            Debug.Log(colObj);
            _colObjHp = collision.gameObject.GetComponent<TestEnemyHp>();
            _colObjHp.Damage(_damage);
        }
        //�J�j�̏ꍇ�̓_���[�W�ł͂Ȃ��ꔭ�ŏ�Ԃ�ς���
        if(collision.tag == _clabTag)
        {
            _colKaniScript = collision.gameObject.GetComponent<Kani>();
            //��ŃJ�j�̏�ԕω��̏�����ǉ�����
        }
    }
}
