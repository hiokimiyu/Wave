using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Tooltip("�e�̑���")]
    [SerializeField] float _speed = 1f;
    [Tooltip("Player�̃^�O")]
    [SerializeField, TagName] string _playerTag;
    /// <summary>Player�̃I�u�W�F�N�g</summary>
    GameObject _player;
    float timer;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag(_playerTag);
    }

    void Update()
    {
        //���@�_��
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
