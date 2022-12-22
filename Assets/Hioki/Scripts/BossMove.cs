using UnityEngine;

public class BossMove : MonoBehaviour, IDamage
{
    [Tooltip("�o��������G�l�~�[")]
    [SerializeField] private GameObject[] _enemy = new GameObject[3];
    [Tooltip("�G�l�~�[���o���Ƃ���")]
    [SerializeField] private Transform _spawnPos;
    [SerializeField] private Sprite[] _sprite = new Sprite[3];
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private SoundManager _soundManager;
    //����������Serialize����K�v������

    [Range(0, 100)]
    [SerializeField] private float _hp = 10f;
    [Tooltip("�����Ȃ鎞�̎c��HP")]
    [SerializeField] private int _powerUpHp = 4;
    [Tooltip("�~�܂���������ړ�����܂ł̎���")]
    [Range(1, 10)]
    [SerializeField] private float _moveTime = 3f;

    /// <summary> �����Ȃ�Ƃ��Ƀ}�C�i�X����~�܂鎞�� </summary>
    private readonly float _reduceTime = 2f;
    /// <summary> ��������_���[�W </summary>
    private readonly float _damage = 1;
    /// <summary> �~�ړ��X�s�[�h </summary>
    private readonly float _circleSpeed = 1f;
    /// <summary> �G���o���Ƃ��Ɏ~�܂鎞�� </summary>
    private float _stopTime = 3f;
    /// <summary> �~�̔��a </summary>
    private readonly float _circleRadius = 5f;
    /// <summary>���ړ������邽�߂̃^�C�}�[</summary>
    private float _time = 0;
    /// <summary>���[�h�؂�ւ��ɑΉ�����G���o�����߂̐���</summary>
    private int _mode = 0;
    /// <summary>�o�����G�l�~�[���J�E���g����</summary>
    private int _enemyCount = 0;
    /// <summary>�U���������ǂ���</summary>
    private bool _isAttack;
    /// <summary>�ŏ��̎����̈ʒu�����Ă���</summary>
    private Vector2 _startPos;
    /// <summary>�X�v���C�g</summary>
    private SpriteRenderer _sr;

    [Header("�e�X�g�p")]
    [Tooltip("���̏o����")]
    [SerializeField] private int _enemyNum;
    /// <summary> �����̍s�� </summary>
    private AttackPattern _attackPattern = AttackPattern.Normal;
    /// <summary>���[�h�ؑւ�ړ��Ԋu�͂���^�C�}�[</summary>
    private float _timer = 0;
    /// <summary> ���C���[�̔ԍ� </summary>
    private int _layerNum = 0;
    /// <summary> �s���������ǂ��� </summary>
    private bool _isMode = false;
    /// <summary> �p���[�A�b�v������ </summary>
    private bool _isPowerUp = false;

    private void Start()
    {
        _startPos = transform.position;
        _sr = GetComponent<SpriteRenderer>();
        //_circleRadius *= _isLeft ? 1 : -1;
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
            case AttackPattern.Normal:

                //�����̂���Ƃ���
                Vector2 pos = transform.position;
                //�������߂Ă�͂�
                float theta = _circleSpeed * _time * Mathf.PI;

                _sr.sprite = _sprite[_mode];
                //cos�� * ���a �ł������߂Ă�
                //�����̍ŏ��̈ʒu���瓮�������߃v���X����A�[����n�߂邽�ߔ��a���}�C�i�X
                pos.x = Mathf.Cos(theta) * _circleRadius + _startPos.x - _circleRadius;
                pos.y = Mathf.Sin(theta) * _circleRadius;
                _time += Time.deltaTime;
                transform.position = pos;

                if (_enemyCount <= _enemyNum)
                {
                    Spawn();
                }
                break;

            /// <summary> ��(��)�N�o�����̍s�� </summary>
            case AttackPattern.Flame:
            case AttackPattern.Snow:

                _sr.sprite = _sprite[_mode];
                Attack();
                break;
        }
    }

    private void Attack()
    {
        if (!_isAttack)
        {
            _layerNum = _mode + 5; //�f�o�b�N���₷���悤�ɕϐ��ɓ����
            SetLayer(_layerNum); //���C���[��6�C7�ɂ���
            _isAttack = true;
            Spawn();
        }

        if (_timer > _moveTime + _stopTime)
        {
            _isAttack = false;
            _attackPattern = AttackPattern.Normal;
            _isMode = false;
            _mode = 0;
            _timer = 0;
            _enemyCount = 0;
            _layerNum = _mode;
            SetLayer(_layerNum);
        }//��莞�Ԃ�������ړ�������A���C���[��0�ɖ߂�
    }

    /// <summary>�{�X�����C���[�ύX����</summary>
    /// <param name="num">���C���[�̔ԍ�</param>
    private void SetLayer(int num)
    {
        gameObject.layer = num;
    }

    private void Spawn()
    {
        _enemyCount++;
        int y = Random.Range(0, 2) == 0 ? 0 : 180;

        Instantiate(_enemy[_mode], _spawnPos.position,
            Quaternion.Euler(0, y, 0), _gameManager.EnemyParent.transform);
    }

    void IDamage.Damage()
    {
        _hp -= _damage;
        _soundManager.AudioPlay(_soundManager.AttackAudios[4]);
    }

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
