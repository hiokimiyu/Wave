using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWave : MonoBehaviour
{
    /// <summary>Rigidbodyの変数</summary>
    Rigidbody2D _rb;
    [Tooltip("弾のスピード")]
    [SerializeField]float _speed;
    [Tooltip("カニのタグ")]
    [SerializeField, TagName] string _clabTag;
    [Tooltip("音波が与えるダメージ")]
    [SerializeField] int _damage;
    Kani _colKaniScript;
    /// <summary>飛ぶ方向の変数</summary>
    public float _dir = 1;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.right * _speed * _dir;
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //カニの場合はダメージではなく一発で状態を変える
        if (collision.tag == _clabTag)
        {
            _colKaniScript = collision.gameObject.GetComponent<Kani>();
            //後でカニの状態変化の処理を追加する
        }
        //スポナーにダメージを与える処理も後で追加する
    }
}
