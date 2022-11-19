using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kani : MonoBehaviour
{
    Rigidbody2D _rb;
    [Tooltip("移動スピード")]
    [SerializeField] float _speed = 5;
    [Tooltip("壁のオブジェクトのタグ名")]
    [SerializeField, TagName] string _wallTag;
    [Tooltip("かにの状態")]
    [SerializeField] bool _isStop;
    [Tooltip("かにが消える時間")]
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
        }//動ける状態
        else if (_isStop)
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
            _deleteTime -= Time.deltaTime;

            if (_deleteTime < 0)
            {
                Destroy(gameObject);
            }//時間になったら消す
        }//動けない状態

        //方向転換
        transform.eulerAngles = _speed < 0 ? new Vector3(0, 180, 0) : new Vector3(0, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _wallTag)
        {
            _speed *= -1f;
        }//方向転換
    }
}
