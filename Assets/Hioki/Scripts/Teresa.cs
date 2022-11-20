using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teresa : MonoBehaviour
{
    Rigidbody2D _rb;
    [Tooltip("横移動スピード")]
    [SerializeField] float _xSpeed = 5;
    [Tooltip("縦移動")]
    [SerializeField] float _ySpeed = 0;
    [Tooltip("壁のオブジェクトのタグ名")]
    [SerializeField, TagName] string _wallTag;
    [Tooltip("攻撃間隔")]
    [SerializeField] float _attackTime = 3;
    /// <summary>攻撃間隔はかるタイマー</summary>
    float _attack = 0;
    [Tooltip("muzzle")]
    [SerializeField] Transform _muzzle;
    [Tooltip("弾")]
    [SerializeField] GameObject _bullet;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        //自分がどっち向いてるか確認して、進む方向を決めてる
        _xSpeed *= transform.eulerAngles.y == 180 ? 1 : -1;
    }

    void Update()
    {
        _attack += Time.deltaTime;

        if (_attackTime < _attack)
        {
            Instantiate(_bullet, _muzzle.position, transform.rotation, transform);
            _attack = 0;
        }//攻撃

        //移動
        _rb.velocity = new Vector2(_xSpeed, Mathf.Sin(Time.time * _ySpeed));

        //方向転換
        transform.eulerAngles = _xSpeed < 0 ? new Vector3(0, 180, 0) : new Vector3(0, 0, 0);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _wallTag)
        {
            _xSpeed *= -1f;
        }//移動方向
    }
}
