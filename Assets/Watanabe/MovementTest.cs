using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
    private Rigidbody2D _rb2D;
    private float _time = 0f;

    [Tooltip("ˆÚ“®‘¬“x")]
    [SerializeField] private float _moveSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float y = transform.localRotation.y;
        _rb2D.velocity = new Vector2(_moveSpeed, _rb2D.velocity.y);
        _time += Time.deltaTime;

        if (_time > 1f)
        {
            _time = 0f;
            y = y == 0 ? 180 : 0;
            _moveSpeed *= -1;
        }
    }
}
