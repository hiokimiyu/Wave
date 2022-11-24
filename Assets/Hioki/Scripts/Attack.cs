using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [Tooltip("攻撃力")]
    [SerializeField] int _attack;
    [Tooltip("プレイヤータグ")]
    [SerializeField, TagName] string _playerTag;
    private void Start()
    {
        
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.tag == _playerTag)
    //    {
    //        var player = collision.gameObject.GetComponent<PlayerMove>();
    //        player.Damage(_attack);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == _playerTag)
        {
            var player = collision.gameObject.GetComponent<PlayerMove>();
            player.Damage(_attack);
        }
    }
}
