using UnityEngine;

public class BossMove : MonoBehaviour, IDamage
{
    [Tooltip("GameManager")]
    [SerializeField] GameManager _gameManager;
    [Tooltip("エネミー")]
    [SerializeField] GameObject[] _enemy = new GameObject[3];
    [Tooltip("エネミーを出すところ")]
    [SerializeField] Transform _spawnPos;
    [Tooltip("HP")]
    [SerializeField, Range(0, 100)] float _hp = 10f;
    [Tooltip("強くなる時の残りHP")]
    [SerializeField] float _powerUpHp = 4f;
    [Tooltip("強くなるときにマイナスする止まる時間")]
    [SerializeField] float _reduceTime = 2f;
    [Tooltip("あたえるダメージ")]
    [SerializeField] float _damage = 1;
    [Tooltip("止まった所から移動するまでの時間")]
    [SerializeField, Range(1, 10)] float _moveTime = 3f;
    [Tooltip("敵を出すときに止まる時間")]
    [SerializeField] float _stopTime = 3f;
    [Tooltip("円移動スピード")]
    [SerializeField] float _circleSpeed = 1f;
    [Tooltip("円の半径")]
    [SerializeField] float _circleRadius = 5f;
    /// <summary>横移動させるためのタイマー</summary>
    float _time = 0;
    [Tooltip("左に行くか")]
    [SerializeField] bool _isLeft;
    /// <summary>最初の自分の位置を入れておく</summary>
    Vector2 _startPos;
    /// <summary>攻撃したかどうか</summary>
    bool _isAttack;
    /// <summary>モード切り替えに対応する敵を出すための数字</summary>
    int _mode = 0;
    /// <summary>出したエネミーをカウントする</summary>
    int _enemyCount = 0;

    //デバックするため見えるようにしておく↓

    [Tooltip("行動したかどうか")]
    [SerializeField] bool _isMode = false;
    [Tooltip("パワーアップしたか")]
    [SerializeField] bool _isPowerUp = false;
    /// <summary>モード切替や移動間隔はかるタイマー</summary>
    [SerializeField] float _timer = 0;
    [Tooltip("何体出すか")]
    [SerializeField] int _enemyNum;
    [Tooltip("自分の行動")]
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
            //enumを_modeで２つのうちランダムに行動を決める
            _mode = Random.Range(1, 3);
            _attackPattern = (AttackPattern)_mode;
            _isMode = true;
        }
        if (!_isPowerUp && _hp <= _powerUpHp)
        {
            _isPowerUp = true;
            _moveTime -= _reduceTime;
            _stopTime -= _reduceTime;
        }//パワーアップする処理　＝＞　移動時間が減るなど

        switch (_attackPattern)
        {
            /// <summary>ノーマルの時の行動</summary>
            case AttackPattern.Normal: // == 0

                //自分のいるところ
                Vector2 pos = transform.position;
                //Θを求めてるはず
                float rad = _circleSpeed * _time * Mathf.PI;
                //cosΘ * 半径 でｘを求めてる,
                //自分の最初の位置から動かすためプラスする、端から始めるため半径をマイナス
                pos.x = Mathf.Cos(rad) * _circleRadius + _startPos.x - _circleRadius;
                pos.y = Mathf.Sin(rad) * _circleRadius;
                transform.position = pos;
                _time += Time.deltaTime;
                if (_enemyCount <= _enemyNum)
                {
                    Spawn();
                }
                break;

            /// <summary>炎君出す時の行動</summary>
            case AttackPattern.Flame: // == 1
                Attack();
                break;

            ///<summary>雪君出す時の行動</summary>
            case AttackPattern.Snow: // == 2
                Attack();
                break;
        }
    }

    private void Attack()
    {
        if (!_isAttack)
        {
            _isAttack = true;
            Spawn();
        }
        if (_timer > _moveTime + _stopTime)
        {
            _isAttack = false;
            _attackPattern = AttackPattern.Normal;
            _isMode = false;
            _timer = 0;
            _enemyCount = 0;
        }//一定時間たったら移動させる
    }

    void IDamage.Damage()
    {
        _hp -= _damage;
    }

    /// <summary>自分の行動</summary>
    enum AttackPattern
    {
        /// <summary>移動だけ、何もしないとき</summary>
        Normal,
        ///<summary>炎を出すとき</summary>
        Flame,
        /// <summary>雪を出すとき</summary>
        Snow,
    }

    void Spawn()
    {
        _enemyCount++;
        int y = Random.Range(0, 2) == 0 ? 0 : 180;
        Instantiate(_enemy[_mode], _spawnPos.position, Quaternion.Euler(0, y, 0), _gameManager.EnemyParent.transform);
    }
}
