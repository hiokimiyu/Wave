using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Tooltip("�e�̑���")]
    [SerializeField] float _speed = 1f;
    GameObject _player;
    void Start()
    {
        _player = GameObject.Find("Player");
    }

    void Update()
    {
        //���@�_��
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
    }
}
