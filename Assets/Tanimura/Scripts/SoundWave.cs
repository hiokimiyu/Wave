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
    [Tooltip("スポナーのタグ")]
    [SerializeField, TagName] string _spownerTag;
    [Tooltip("音波が与えるダメージ")]
    [SerializeField] int _damage;
    [SerializeField] float _lifeTime;
    IDamage _iDamage;
    /// <summary>飛ぶ方向の変数</summary>
    float _dir = 1;  //プロパティ化
    public float Dir { get => _dir; set => _dir = value; }


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.right * _speed * _dir;
        _iDamage = GetComponent<IDamage>();
    }
    void Update()
    {
        _lifeTime -= Time.deltaTime;
        if(_lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //カニの場合はダメージではなく一発で状態を変える
        if (collision.tag == _clabTag || collision.tag == _spownerTag)
        {
            collision.gameObject.GetComponent<IDamage>().Damage();
            //_iDamage.Damage();
            //後でカニの状態変化の処理を追加する
        }
        
        //スポナーにダメージを与える処理も後で追加する
    }
}
