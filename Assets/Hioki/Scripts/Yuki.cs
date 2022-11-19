using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yuki : MonoBehaviour
{
    Rigidbody2D _rb;
    [Tooltip("���ړ��X�s�[�h")]
    [SerializeField] float _xSpeed = 5;
    [Tooltip("�c�ړ�")]
    [SerializeField] float _ySpeed = 0;
    [Tooltip("�ǂ̃I�u�W�F�N�g�̃^�O��")]
    [SerializeField, TagName] string _wallTag;
    [Tooltip("�U���Ԋu")]
    [SerializeField] float _attackTime = 3;
    [Tooltip("�U���^�C��")] float _attack = 0;
    [Tooltip("muzzle")]
    [SerializeField] Transform _muzzle;
    [Tooltip("�e")]
    [SerializeField] GameObject _bullet;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _attack += Time.deltaTime;
        if (_attackTime < _attack)
        {
            Instantiate(_bullet, _muzzle.position, transform.rotation);
            _attack = 0;
        }//�U��

        //�ړ�
        _rb.velocity = new Vector2(_xSpeed, Mathf.Sin(Time.time * _ySpeed));

        //�����]��
        transform.eulerAngles = _xSpeed < 0 ? new Vector3(0, 180, 0) : new Vector3(0, 0, 0);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _wallTag)
        {
            _xSpeed *= -1f;
        }//�ړ�����
    }
}
