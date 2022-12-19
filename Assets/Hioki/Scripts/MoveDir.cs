using UnityEngine;

public class MoveDir : MonoBehaviour
{
    [Tooltip("������")]
    [SerializeField] private float _length = 4.0f;
    [Tooltip("�����X�s�[�h")]
    [SerializeField] private float _speed = 2.0f;
    [Tooltip("�c�ɓ��������ɓ�����")]
    [SerializeField] private bool _isMoveType = false;

    /// <summary>�ŏ��̈ʒu</summary>
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
        }//���E�ɓ����Ƃ�
        else
        {
            transform.position = new Vector2((Mathf.Sin((Time.time) * _speed) * _length + _startPos.x), _startPos.y);
        }//�c�ɓ����Ƃ�
    }
}