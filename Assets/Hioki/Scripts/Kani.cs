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
    /// <summary>�Ђ�����Ԃ�Ƃ��̉�]���l</summary>
    float _z = 0;

    //�e�X�g���₷���悤�Ɍ�����悤�ɂ��Ă������́�
    [Tooltip("���ɂ̍U����")]
    [SerializeField] float _crabPower = 2;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        //�������ǂ��������Ă邩�m�F���āA�i�ޕ��������߂Ă�
        _speed *= transform.eulerAngles.y == 180 ? 1 : -1;
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
            _z = 180;
            _deleteTime -= Time.deltaTime;

            if (_deleteTime < 0)
            {
                Destroy(gameObject);
            }//���ԂɂȂ��������
        }//�����Ȃ����

        //�����]��
        transform.eulerAngles = _speed < 0 ? new Vector3(0, 180, _z) : new Vector3(0, 0, _z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _wallTag || collision.gameObject.tag == gameObject.tag)
        {
            _speed *= -1f;
        }//�����]��
    }
}
