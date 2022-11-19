using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 反転処理のテスト
/// </summary>
public class MovementTest : MonoBehaviour
{
    private Rigidbody2D _rb2D;
    /// <summary> シーン内の時間 </summary>
    private float _time = 0f;
    
    [Tooltip("移動速度")]
    [SerializeField] private float _moveSpeed = 1f;
    [Tooltip("反転するまでの時間")]
    [SerializeField, Range(1f, 5f)] private float _rotateTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //移動
        float y = 0f;
        _rb2D.velocity = new Vector2(_moveSpeed, _rb2D.velocity.y);
        _time += Time.deltaTime;

        //一定時間経ったら、反転する
        if (_time > _rotateTime)
        {
            _time = 0f;
            y = y == 0f ? 180.0f : 0.0f;
            _moveSpeed *= -1;
        }
        //オブジェクトの回転(反転)
        transform.Rotate(0, y, 0);
    }
}
