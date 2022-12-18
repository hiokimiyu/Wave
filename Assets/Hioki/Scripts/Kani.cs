using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kani : MonoBehaviour, IDamage
{
    [Tooltip("�ړ��X�s�[�h")]
    [SerializeField] private float _speed = 5;
    [Tooltip("���ɂ̏��")]
    [SerializeField] private bool _isStop;
    [Tooltip("���ɂ������鎞��")]
    [SerializeField] private float _deleteTime = 3;

    /// <summary>�Ђ�����Ԃ�Ƃ��̉�]���l</summary>
    private float _rotateZ = 0;
    private readonly string _wallTag ="Wall";
    private readonly string _bossTag = "Boss";
    private Rigidbody2D _rb;
    private SoundManager _soundManager;
    /// <summary>�U���Ȃ���</summary>
    private Attack _attack;

    //�e�X�g���₷���悤�Ɍ�����悤�ɂ��Ă������́�

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _attack = GetComponent<Attack>();
        _soundManager = GameObject.Find("Managers").GetComponent<SoundManager>();

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
            _rotateZ = 180;
            _deleteTime -= Time.deltaTime;

            if (_deleteTime < 0)
            {
                Destroy(gameObject);
            }//���ԂɂȂ��������
        }//�����Ȃ����

        //�����]��
        transform.eulerAngles = _speed < 0 ? new Vector3(0, 180, _rotateZ) : new Vector3(0, 0, _rotateZ);
    }

    void IDamage.Damage()
    {
        //���ɂ��X�g�b�v����
        _isStop = true;
        _attack.enabled = false;
        _soundManager.AudioPlay(_soundManager.AttackAudios[4]);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //���ׁA�����Ɠ����^�O�ɓ���������
        if (col.gameObject.CompareTag(_wallTag) || col.gameObject.CompareTag(gameObject.tag))
        {
            _speed *= -1f;
        }//�����]��

        if (col.gameObject.CompareTag(_bossTag))
        {
            col.gameObject.GetComponent<IDamage>().Damage();
        }
    }
}
