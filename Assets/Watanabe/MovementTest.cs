using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���]�����̃e�X�g
/// </summary>
public class MovementTest : MonoBehaviour
{
    private Rigidbody2D _rb2D;
    /// <summary> �V�[�����̎��� </summary>
    private float _time = 0f;
    
    [Tooltip("�ړ����x")]
    [SerializeField] private float _moveSpeed = 1f;
    [Tooltip("���]����܂ł̎���")]
    [SerializeField, Range(1f, 5f)] private float _rotateTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //�ړ�
        float y = 0f;
        _rb2D.velocity = new Vector2(_moveSpeed, _rb2D.velocity.y);
        _time += Time.deltaTime;

        //��莞�Ԍo������A���]����
        if (_time > _rotateTime)
        {
            _time = 0f;
            y = y == 0f ? 180.0f : 0.0f;
            _moveSpeed *= -1;
        }
        //�I�u�W�F�N�g�̉�](���])
        transform.Rotate(0, y, 0);
    }
}
