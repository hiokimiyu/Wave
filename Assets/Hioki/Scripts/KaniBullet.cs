using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaniBullet : MonoBehaviour
{
    Rigidbody2D _rb;
    [Tooltip("îÚÇŒÇ∑óÕ")]
    [SerializeField] float _power = 5;
    [Tooltip("è∞ÇÃÉ^ÉO")]
    [SerializeField, TagName] string _groundTag;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(gameObject.transform.right * _power, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _groundTag)
        {
            Destroy(gameObject);
        }
    }
}
