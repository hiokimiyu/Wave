using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWave : MonoBehaviour
{
    [Tooltip("音波が与えるダメージ")]
    [SerializeField] private int _damage;
    [SerializeField] private float _lifeTime;

    private readonly string _clabTag = "Crab";
    private readonly string _spownerTag = "Spawner";
    /// <summary> Rigidbodyの変数 </summary>
    Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = GameObject.Find("TestPlayer").transform.localScale.x * Vector2.right;
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
        if (collision.CompareTag(_clabTag) || collision.CompareTag(_spownerTag))
        {
            collision.gameObject.GetComponent<IDamage>().Damage();
            //後でカニの状態変化の処理を追加する
        }
    }
}
