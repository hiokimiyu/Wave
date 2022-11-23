using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kani : MonoBehaviour, IDamage
{
    Rigidbody2D _rb;
    [Tooltip("移動スピード")]
    [SerializeField] float _speed = 5;
    [Tooltip("壁のオブジェクトのタグ名")]
    [SerializeField, TagName] string _wallTag;
    [Tooltip("スポナーのタグ")]
    [SerializeField, TagName] string _spawnerTag;
    [Tooltip("かにの状態")]
    [SerializeField] bool _isStop;
    [Tooltip("かにが消える時間")]
    [SerializeField] float _deleteTime = 3;
    /// <summary>ひっくり返るときの回転数値</summary>
    float _z = 0;

    //テストしやすいように見えるようにしておくもの↓

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        //自分がどっち向いてるか確認して、進む方向を決めてる
        _speed *= transform.eulerAngles.y == 180 ? 1 : -1;
    }

    void Update()
    {
        if (!_isStop)
        {
            _rb.velocity = new Vector2(_speed, _rb.velocity.y);
        }//動ける状態
        else if (_isStop)
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
            _z = 180;
            _deleteTime -= Time.deltaTime;

            if (_deleteTime < 0)
            {
                Destroy(gameObject);
            }//時間になったら消す
        }//動けない状態

        //方向転換
        transform.eulerAngles = _speed < 0 ? new Vector3(0, 180, _z) : new Vector3(0, 0, _z);
    }

    void IDamage.Damage()
    {
        //かにがストップする
        _isStop = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //かべ、自分と同じタグに当たったら
        if (collision.gameObject.tag == _wallTag || collision.gameObject.tag == gameObject.tag)
        {
            _speed *= -1f;
        }//方向転換

        if (collision.gameObject.tag == _spawnerTag)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }//スポナーに当たったら消す
    }
}
