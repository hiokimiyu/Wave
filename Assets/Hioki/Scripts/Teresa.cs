using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teresa : MonoBehaviour, IDamage
{
    Rigidbody2D _rb;
    [Tooltip("横移動スピード")]
    [SerializeField] float _xSpeed = 5;
    [Tooltip("縦移動")]
    [SerializeField] float _ySpeed = 0;
    [Tooltip("攻撃間隔")]
    [SerializeField] float _attackTime = 3;
    [Tooltip("壁のオブジェクトのタグ名")]
    [SerializeField, TagName] string _wallTag;
    [Tooltip("muzzle")]
    [SerializeField] Transform _muzzle;
    [Tooltip("弾")]
    [SerializeField] GameObject _bullet;
    /// <summary>攻撃間隔はかるタイマー</summary>
    float _attackTimer = 0;

    //テストしやすいように見えるようにしておくもの↓
    [Tooltip("HP")]
    [SerializeField] int _hp = 5;
    [Tooltip("ダメージ量")]
    [SerializeField] int _damage = 5;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        //自分がどっち向いてるか確認して、進む方向を決めてる
        _xSpeed *= transform.eulerAngles.y == 180 ? 1 : -1;
    }

    void Update()
    {
        _attackTimer += Time.deltaTime;

        if (_attackTime < _attackTimer)
        {
            Instantiate(_bullet, _muzzle.position, transform.rotation, transform);
            _attackTimer = 0;
        }//攻撃

        //移動
        _rb.velocity = new Vector2(_xSpeed, Mathf.Sin(Time.time * _ySpeed));

        //方向転換
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
    //    }//移動方向
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == _wallTag)
        {
            _xSpeed *= -1f;
        }//移動方向
    }
}
