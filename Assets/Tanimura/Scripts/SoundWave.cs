using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWave : MonoBehaviour
{
    /// <summary>Rigidbodyの変数</summary>
    Rigidbody2D _rb;
    [Tooltip("弾のスピード")]
    [SerializeField]float _speed;
    float _dir;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.right * _speed * _dir;
    }
    void Update()
    {
        
    }
}
