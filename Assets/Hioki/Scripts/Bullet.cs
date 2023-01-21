using Consts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour,IDamage
{
    [Tooltip("�e�̑���")]
    [SerializeField] private float _speed = 1f;
    [Tooltip("�e��HP")]
    [SerializeField] private int _hp = 1;

    private float _timer = default;
    private GameObject _player = default;
    private SoundManager _soundManager = default;

    void Start()
    {
        _soundManager = GameObject.Find("Managers").GetComponent<SoundManager>();
        _player = GameObject.FindGameObjectWithTag(Constants.PLAYER_TAG);
    }

    void Update()
    {
        //���@�_��
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);

         _timer += Time.deltaTime;

        if(_timer >= 3 || _hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Constants.PLAYER_TAG) || 
            collision.gameObject.CompareTag(Constants.FLAME_TAG))
        {
            Destroy(gameObject);
        }
    }

    void IDamage.Damage()
    {
        _hp--;
        _soundManager.AudioPlay(_soundManager.AttackAudios[0]);
    }
}
