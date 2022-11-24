using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Tooltip("弾の速さ")]
    [SerializeField] float _speed = 1f;
    [Tooltip("Playerのタグ")]
    [SerializeField, TagName] string _playerTag;
    /// <summary> Playerのオブジェクト </summary>
    GameObject _player;
    /// <summary> オブジェクト出現後からのタイマー </summary>
    float _timer;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag(_playerTag);
    }

    void Update()
    {
        //自機狙い
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);

         _timer += Time.deltaTime;

        if(_timer >= 3)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == _playerTag)
        {
            Destroy(gameObject);
        }
    }
}
