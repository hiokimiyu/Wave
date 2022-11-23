using UnityEngine;

public class BossMove : MonoBehaviour, IDamage
{
    [Tooltip("GameManager")]
    [SerializeField] GameManager _gameManager;
    [Tooltip("�G�l�~�[")]
    [SerializeField] GameObject[] _enemy = new GameObject[2];
    [Tooltip("�G�l�~�[���o���Ƃ���")]
    [SerializeField] Transform _spawnPos;
    [Tooltip("HP")]
    [SerializeField, Range(0, 100)] float _hp = 10f;
    [Tooltip("�����Ȃ鎞�̎c��HP")]
    [SerializeField] float _powerUpHp = 4f;
    [Tooltip("�����Ȃ�Ƃ��Ƀ}�C�i�X����~�܂鎞��")]
    [SerializeField] float _reduceTime = 2f;
    [Tooltip("��������_���[�W")]
    [SerializeField] float _dmage = 1;
    [Tooltip("�~�܂���������ړ�����܂ł̎���")]
    [SerializeField, Range(1, 10)] float _moveTime = 3f;
    [Tooltip("�G���o���Ƃ��Ɏ~�܂鎞��")]
    [SerializeField] float _stopTime = 3f;
    [Tooltip("�~�ړ��X�s�[�h")]
    [SerializeField] float _circleSpeed = 1f;
    [Tooltip("�~�̔��a")]
    [SerializeField] float _circleRadius = 5f;
    /// <summary>���ړ������邽�߂̃^�C�}�[</summary>
    float _time = 0;
    [Tooltip("���ɍs����")]
    [SerializeField] bool _isLeft;
    /// <summary>�ŏ��̎����̈ʒu�����Ă���</summary>
    Vector2 _startPos;
    bool _isAtack;
    int _mode = 0;

    //�f�o�b�N���邽�ߌ�����悤�ɂ��Ă�����

    [Tooltip("�s���������ǂ���")]
    [SerializeField] bool _isMode = false;
    [Tooltip("�p���[�A�b�v������")]
    [SerializeField] bool _isPowerUp = false;
    /// <summary>���[�h�ؑւ�ړ��Ԋu�͂���^�C�}�[</summary>
    [SerializeField] float _timer = 0;
    [Tooltip("�����̍s��")]
    [SerializeField] AttackPattern _attackPattern;

    private void Start()
    {
        _startPos = transform.position;
        _circleRadius *= _isLeft ? 1 : -1;
    }
    private void Update()
    {
        _timer += Time.deltaTime;

        if (_moveTime < _timer && !_isMode)
        {
            //enum��_mode�łQ�̂��������_���ɍs�������߂�
            _mode = Random.Range(1, 3);
            _attackPattern = (AttackPattern)_mode;
            _isMode = true;
        }
        if (!_isPowerUp && _hp <= _powerUpHp)
        {
            _isPowerUp = true;
            _moveTime -= _reduceTime;
            _stopTime -= _reduceTime;
        }//�p���[�A�b�v���鏈���@�����@�ړ����Ԃ�����Ȃ�

        switch (_attackPattern)
        {
            /// <summary>�m�[�}���̎��̍s��</summary>
            case AttackPattern.Normal: // == 0

                //�����̂���Ƃ���
                Vector2 pos = transform.position;
                //�������߂Ă�͂�
                float rad = _circleSpeed * _time * Mathf.PI;
                //cos�� * ���a �ł������߂Ă�,
                //�����̍ŏ��̈ʒu���瓮�������߃v���X����A�[����n�߂邽�ߔ��a���}�C�i�X
                pos.x = Mathf.Cos(rad) * _circleRadius + _startPos.x - _circleRadius;
                pos.y = Mathf.Sin(rad) * _circleRadius;
                transform.position = pos;
                _time += Time.deltaTime;
                break;

            /// <summary>���N�o�����̍s��</summary>
            case AttackPattern.Flame: // == 1
                if (!_isAtack)
                {
                    _isAtack = true;
                    int y = Random.Range(0, 2) == 0 ? 0 : 180;
                    Instantiate(_enemy[_mode], _spawnPos.position, Quaternion.Euler(0, y, 0), _gameManager.EnemyParent.transform);
                }
                if (_timer > _moveTime + _stopTime)
                {
                    _attackPattern = AttackPattern.Normal;
                    _isMode = false;
                    _isAtack = false;
                    _timer = 0;
                }//��莞�Ԃ�������ړ�������
                break;

            ///<summary>��N�o�����̍s��</summary>
            case AttackPattern.Snow: // == 2
                if (!_isAtack)
                {
                    _isAtack = true;
                    int y = Random.Range(0, 2) == 0 ? 0 : 180;
                    Instantiate(_enemy[_mode], _spawnPos.position, Quaternion.Euler(0, y, 0), _gameManager.EnemyParent.transform);
                }
                if (_timer > _moveTime + _stopTime)
                {
                    _isAtack = false;
                    _attackPattern = AttackPattern.Normal;
                    _isMode = false;
                    _timer = 0;
                }//��莞�Ԃ�������ړ�������
                break;
        }
    }

    void IDamage.Damage()
    {
        _hp -= _dmage;
    }

    //���A��̎��͎����͔��΂̑����������Ă���
    /// <summary>�����̍s��</summary>
    enum AttackPattern
    {
        /// <summary>�ړ������A�������Ȃ��Ƃ�</summary>
        Normal,
        ///<summary>�����o���Ƃ�</summary>
        Flame,
        /// <summary>����o���Ƃ�</summary>
        Snow,
    }
}
