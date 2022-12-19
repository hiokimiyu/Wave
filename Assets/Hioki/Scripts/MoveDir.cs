using UnityEngine;

public class MoveDir : MonoBehaviour
{
    [Tooltip("動く幅")]
    [SerializeField] private float _length = 4.0f;
    [Tooltip("動くスピード")]
    [SerializeField] private float _speed = 2.0f;
    [Tooltip("縦に動くか横に動くか")]
    [SerializeField] private bool _isMoveType = false;

    /// <summary>最初の位置</summary>
    private Vector3 _startPos;

    void Start()
    {
        _startPos = transform.position;
    }

    void FixedUpdate()
    {
        if (_isMoveType)
        {
            transform.position = new Vector2(_startPos.x, Mathf.Sin((Time.time) * _speed) * _length + _startPos.y);
        }//左右に動くとき
        else
        {
            transform.position = new Vector2((Mathf.Sin((Time.time) * _speed) * _length + _startPos.x), _startPos.y);
        }//縦に動くとき
    }
}