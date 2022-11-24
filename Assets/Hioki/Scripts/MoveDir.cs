using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDir : MonoBehaviour
{
    [Tooltip("動く幅")]
    [SerializeField] float _length = 4.0f;
    [Tooltip("動くスピード")]
    [SerializeField] float _speed = 2.0f;
    [Tooltip("縦に動くか横に動くか")]
    [SerializeField] bool _isMoveType = false;
    /// <summary>最初の位置</summary>
    Vector3 _startPos;

    void Start()
    {
        _startPos = transform.position;
    }

    void FixedUpdate()
    {
        if (_isMoveType)
        {
            transform.position = new Vector2(_startPos.x, Mathf.Sin((Time.time) * _speed) * _length + _startPos.y);
        }
        else
        {
            transform.position = new Vector2((Mathf.Sin((Time.time) * _speed) * _length + _startPos.x), _startPos.y);
        }
    }
}