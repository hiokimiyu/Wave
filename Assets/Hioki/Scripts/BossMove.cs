using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    [Tooltip("止まった所から移動するまでの時間")]
    [SerializeField] float _moveTime = 3f;
    [Tooltip("円移動スピード")]
    [SerializeField] float _circleSpeed = 1f;
    [Tooltip("円の半径")]
    [SerializeField] float _circleradius = 5;
    [Tooltip("左に行くか")]
    [SerializeField] bool _isLeft;

    //デバックするため見えるようにしておく↓

    /// <summary>モード切替や移動間隔はかるタイマー</summary>
    [SerializeField] float _timer = 0;
    /// <summary>横移動させるためのタイマー</summary>
    float _time = 0;
    [Tooltip("Θ")]
    [SerializeField] float rad;
    Vector2 _startPos;
    [Tooltip("出す敵")]
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
        //自分のいるところ
        Vector2 pos = transform.localPosition;

        //Θを求めてる
        rad = _circleSpeed * _time * Mathf.PI;

        //cosΘ * 半径 でｘを求めてる,
        //自分の最初の位置から動かすためマイナスする
        pos.x = Mathf.Cos(rad) * _circleradius - _circleradius;

        transform.position = pos;

        _time += Time.deltaTime;
    }

    //かには常時出しておく
    //炎、雪の時は自分は反対の属性を持っておく
    /// <summary>自分の</summary>
    enum AttackPattern
    {
        /// <summary>移動だけ、何もしないとき</summary>
        Normal,
        ///<summary>炎を出すとき</summary>
        Flame,
        /// <summary>雪を出すとき</summary>
        Snow,
    }
}
