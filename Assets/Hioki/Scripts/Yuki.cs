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
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rb.velocity = new Vector2(_xSpeed, Mathf.Sin(Time.time * _ySpeed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _wallTag)
        {
            _xSpeed *= -1f;
        }//�����]��
    }
}
