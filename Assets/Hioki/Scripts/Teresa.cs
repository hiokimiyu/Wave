using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teresa : MonoBehaviour, IDamage
{
    [SerializeField] private Transform _muzzle;
    [SerializeField] private GameObject _bullet;
    [Tooltip("���ړ��X�s�[�h")]
    [SerializeField] private float _xSpeed = 5;
    [Tooltip("�c�ړ�")]
    [SerializeField] private float _ySpeed = 0;
    [Tooltip("�U���Ԋu")]
    [SerializeField] private float _attackTime = 3;

    private readonly string _wallTag = "Wall";
    private float _attackTimer = 0f;
    private SoundManager _soundManager;
    private Rigidbody2D _rb;

    //�e�X�g���₷���悤�Ɍ�����悤�ɂ��Ă������́�
    [Header("�e�X�g�p")]
    [SerializeField] private int _hp = 5;
    [SerializeField] private int _damage = 5;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _soundManager = GameObject.Find("Managers").GetComponent<SoundManager>();

        //�������ǂ��������Ă邩�m�F���āA�i�ޕ��������߂Ă�
        _xSpeed *= transform.eulerAngles.y == 180 ? 1 : -1;
    }

    void Update()
    {
        _attackTimer += Time.deltaTime;

        if (_attackTime < _attackTimer)
        {
            Instantiate(_bullet, _muzzle.position, transform.rotation);
            _attackTimer = 0f;
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
        _soundManager.AudioPlay(_soundManager.AttackAudios[3]);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_wallTag))
        {
            _xSpeed *= -1f;
        }//�ړ�����
    }
}
