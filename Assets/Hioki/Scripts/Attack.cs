using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [Tooltip("攻撃力")]
    [SerializeField] int _attack;
    [Tooltip("プレイヤータグ")]
    [SerializeField] private readonly string _playerTag = "Player";

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_playerTag))
        {
            var player = collision.gameObject.GetComponent<PlayerMove>();
            player.Damage(_attack);
        }
    }
}
