using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Tooltip("�e�̑���")]
    [SerializeField] float _speed = 1f;
    [Tooltip("Player�̃^�O")]
    [SerializeField, TagName] string _playerTag;
    /// <summary> Player�̃I�u�W�F�N�g </summary>
    GameObject _player;
    /// <summary> �I�u�W�F�N�g�o���ォ��̃^�C�}�[ </summary>
    float _timer;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag(_playerTag);
    }

    void Update()
    {
        //���@�_��
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
