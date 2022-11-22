using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWave : MonoBehaviour
{
    /// <summary>Rigidbody�̕ϐ�</summary>
    Rigidbody2D _rb;
    [Tooltip("�e�̃X�s�[�h")]
    [SerializeField]float _speed;
    [Tooltip("�J�j�̃^�O")]
    [SerializeField, TagName] string _clabTag;
    [Tooltip("���g���^����_���[�W")]
    [SerializeField] int _damage;
    Kani _colKaniScript;
    /// <summary>��ԕ����̕ϐ�</summary>
    public float _dir = 1;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.right * _speed * _dir;
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�J�j�̏ꍇ�̓_���[�W�ł͂Ȃ��ꔭ�ŏ�Ԃ�ς���
        if (collision.tag == _clabTag)
        {
            _colKaniScript = collision.gameObject.GetComponent<Kani>();
            //��ŃJ�j�̏�ԕω��̏�����ǉ�����
        }
        //�X�|�i�[�Ƀ_���[�W��^���鏈������Œǉ�����
    }
}
