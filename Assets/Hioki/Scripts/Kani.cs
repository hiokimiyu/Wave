using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kani : MonoBehaviour
{
    Rigidbody2D _rb;
    [Tooltip("�ړ��X�s�[�h")]
    [SerializeField] float _speed = 5;
    [Tooltip("�ǂ̃I�u�W�F�N�g�̃^�O��")]
    [SerializeField, TagName] string _wallTag;
    [Tooltip("���ɂ̏��")]
    [SerializeField] bool _isStop;
    [Tooltip("���ɂ������鎞��")]
    [SerializeField] float _deleteTime = 3;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!_isStop)
        {
            _rb.velocity = new Vector2(_speed, _rb.velocity.y);
        }//��������
        else if (_isStop)
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
            _deleteTime -= Time.deltaTime;

            if (_deleteTime < 0)
            {
                Destroy(gameObject);
            }//���ԂɂȂ��������
        }//�����Ȃ����

        //�����]��
        transform.eulerAngles = _speed < 0 ? new Vector3(0, 180, 0) : new Vector3(0, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _wallTag)
        {
            _speed *= -1f;
        }//�����]��
    }
}
