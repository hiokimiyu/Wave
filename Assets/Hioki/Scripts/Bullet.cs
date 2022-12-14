using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour,IDamage
{
    [Tooltip("eĚŹł")]
    [SerializeField] private float _speed = 1f;
    [Tooltip("eĚHP")]
    [SerializeField] private int _hp = 1;

    private float _timer;
    private readonly string _playerTag = "Player";
    private readonly string _attack = "Flame";
    private GameObject _player;
    private SoundManager _soundManager;

    void Start()
    {
        _soundManager = GameObject.Find("Managers").GetComponent<SoundManager>();
        _player = GameObject.FindGameObjectWithTag(_playerTag);
    }

    void Update()
    {
        //Š@_˘
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);

         _timer += Time.deltaTime;

        if(_timer >= 3 || _hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_playerTag) || 
            collision.gameObject.CompareTag(_attack))
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
