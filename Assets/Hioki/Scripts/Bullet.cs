using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Tooltip("弾の速さ")]
    [SerializeField] float _speed = 1f;
    [Tooltip("Playerのタグ")]
    [SerializeField, TagName] string _playerTag;
    /// <summary>Playerのオブジェクト</summary>
    GameObject _player;
    float timer;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag(_playerTag);
    }

    void Update()
    {
        //自機狙い
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);

         timer += Time.deltaTime;

        if(timer >= 3)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == _playerTag)
        {
            Destroy(gameObject);
        }
    }
}
