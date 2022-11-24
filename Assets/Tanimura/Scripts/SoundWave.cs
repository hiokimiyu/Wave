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
    [SerializeField] float _lifeTime;
    Kani _colKaniScript;
    /// <summary>��ԕ����̕ϐ�</summary>
    float _dir = 1;  //�v���p�e�B��
    public float Dir { get => _dir; set => _dir = value; }


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.right * _speed * _dir;
    }
    void Update()
    {
        _lifeTime -= Time.deltaTime;
        if(_lifeTime < 0)
        {
            Destroy(gameObject);
        }
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
