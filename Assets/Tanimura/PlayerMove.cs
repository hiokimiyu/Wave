using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D _rb;
    float _h;
    [SerializeField] float _speed;
    [SerializeField] float _jumpPower;
    bool _isGround = true;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _rb.AddForce(Vector2.right * _h * _speed, ForceMode2D.Force);
        if(Input.GetButtonDown("Jump")&&_isGround)
        {
            _rb.AddForce(Vector2.up  * _jumpPower, ForceMode2D.Impulse);
            _isGround = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Ground")
        {
            _isGround = true;
        }
    }

}
