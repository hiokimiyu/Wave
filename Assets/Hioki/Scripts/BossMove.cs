using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    [Tooltip("�~�܂���������ړ�����܂ł̎���")]
    [SerializeField] float _moveTime = 3f;
    [Tooltip("�~�ړ��X�s�[�h")]
    [SerializeField] float _circleSpeed = 1f;
    [Tooltip("�~�̔��a")]
    [SerializeField] float _circleradius = 5;
    [Tooltip("���ɍs����")]
    [SerializeField] bool _isLeft;

    //�f�o�b�N���邽�ߌ�����悤�ɂ��Ă�����

    /// <summary>���[�h�ؑւ�ړ��Ԋu�͂���^�C�}�[</summary>
    [SerializeField] float _timer = 0;
    /// <summary>���ړ������邽�߂̃^�C�}�[</summary>
    float _time = 0;
    [Tooltip("��")]
    [SerializeField] float rad;
    Vector2 _startPos;
    [Tooltip("�o���G")]
    [SerializeField] AttackPattern _attackPattern;

    private void Start()
    {
        _startPos = transform.position;
        _circleradius *= _isLeft ? 1 : -1;
    }
    private void Update()
    {
        _timer += Time.deltaTime;
        if(_timer > _moveTime)
        {
            Circle();
        }
    }

    void Circle()
    {
        //�����̂���Ƃ���
        Vector2 pos = transform.localPosition;

        //�������߂Ă�
        rad = _circleSpeed * _time * Mathf.PI;

        //cos�� * ���a �ł������߂Ă�,
        //�����̍ŏ��̈ʒu���瓮�������߃}�C�i�X����
        pos.x = Mathf.Cos(rad) * _circleradius - _circleradius;

        transform.position = pos;

        _time += Time.deltaTime;
    }

    //���ɂ͏펞�o���Ă���
    //���A��̎��͎����͔��΂̑����������Ă���
    /// <summary>������</summary>
    enum AttackPattern
    {
        /// <summary>�ړ������A�������Ȃ��Ƃ�</summary>
        Normal,
        ///<summary>�����o���Ƃ�</summary>
        Flame,
        /// <summary>����o���Ƃ�</summary>
        Snow,
    }
}
