using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teresa : MonoBehaviour, IDamage
{
    Rigidbody2D _rb;
    [Tooltip("���ړ��X�s�[�h")]
    [SerializeField] float _xSpeed = 5;
    [Tooltip("�c�ړ�")]
    [SerializeField] float _ySpeed = 0;
    [Tooltip("�U���Ԋu")]
    [SerializeField] float _attackTime = 3;
    [Tooltip("�ǂ̃I�u�W�F�N�g�̃^�O��")]
    [SerializeField, TagName] string _wallTag;
    [Tooltip("muzzle")]
    [SerializeField] Transform _muzzle;
    [Tooltip("�e")]
    [SerializeField] GameObject _bullet;
    /// <summary>�U���Ԋu�͂���^�C�}�[</summary>
    float _attackTimer = 0;

    //�e�X�g���₷���悤�Ɍ�����悤�ɂ��Ă������́�
    [Tooltip("HP")]
    [SerializeField] int _hp = 5;
    [Tooltip("�_���[�W��")]
    [SerializeField] int _damage = 5;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        //�������ǂ��������Ă邩�m�F���āA�i�ޕ��������߂Ă�
        _xSpeed *= transform.eulerAngles.y == 180 ? 1 : -1;
    }

    void Update()
    {
        _attackTimer += Time.deltaTime;

        if (_attackTime < _attackTimer)
        {
            Instantiate(_bullet, _muzzle.position, transform.rotation, transform);
            _attackTimer = 0;
        }//�U��

        //�ړ�
        _rb.velocity = new Vector2(_xSpeed, Mathf.Sin(Time.time * _ySpeed));

        //�����]��
        transform.eulerAngles = _xSpeed < 0 ? new Vector3(0, 180, 0) : new Vector3(0, 0, 0);

        if(_hp <= 0)
        {
            Destroy(gameObject);
        }

    }

    void IDamage.Damage()
    {
        _hp -= _damage;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == _wallTag)
    //    {
    //        _xSpeed *= -1f;
    //    }//�ړ�����
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == _wallTag)
        {
            _xSpeed *= -1f;
        }//�ړ�����
    }
}
