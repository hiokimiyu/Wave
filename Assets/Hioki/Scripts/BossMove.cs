using UnityEngine;

public class BossMove : MonoBehaviour, IDamage
{
    [Tooltip("GameManager")]
    [SerializeField] GameManager _gameManager;
    [Tooltip("エネミー")]
    [SerializeField] GameObject[] _enemy = new GameObject[3];
    [Tooltip("エネミーを出すところ")]
    [SerializeField] Transform _spawnPos;
    [SerializeField] Sprite[] _sprite = new Sprite[3];
    [Tooltip("SoundManager")]
    [SerializeField] SoundManager _soundManager;
    //ここから上はSerializeする必要がある

    [Tooltip("HP")]
    [SerializeField, Range(0, 100)] float _hp = 10f;
    [Tooltip("強くなる時の残りHP")]
    [SerializeField] int _powerUpHp = 4;
    [Tooltip("止まった所から移動するまでの時間")]
    [SerializeField, Range(1, 10)] float _moveTime = 3f;

    /// <summary> 強くなるときにマイナスする止まる時間 </summary>
    readonly float _reduceTime = 2f;
    /// <summary> あたえるダメージ </summary>
    readonly float _damage = 1;
    /// <summary> 円移動スピード </summary>
    readonly float _circleSpeed = 1f;
    /// <summary> 敵を出すときに止まる時間 </summary>
    float _stopTime = 3f;
    /// <summary> 円の半径 </summary>
    float _circleRadius = 5f;
    /// <summary>横移動させるためのタイマー</summary>
    float _time = 0;
    /// <summary>モード切り替えに対応する敵を出すための数字</summary>
    int _mode = 0;
    /// <summary>出したエネミーをカウントする</summary>
    int _enemyCount = 0;
    /// <summary>攻撃したかどうか</summary>
    bool _isAttack;
    /// <summary>最初の自分の位置を入れておく</summary>
    Vector2 _startPos;
    /// <summary>スプライト</summary>
    SpriteRenderer _sr;

    //デバックするため見えるようにしておく↓

    [Tooltip("何体出すか")]
    [SerializeField] int _enemyNum;
    /// <summary> 自分の行動 </summary>
    AttackPattern _attackPattern = AttackPattern.Normal;
    /// <summary>モード切替や移動間隔はかるタイマー</summary>
    float _timer = 0;
    /// <summary> レイヤーの番号 </summary>
    int _layerNum = 0;
    /// <summary> 行動したかどうか </summary>
    bool _isMode = false;
    /// <summary> パワーアップしたか </summary>
    bool _isPowerUp = false;

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

                _sr.sprite = _sprite[_mode];
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
                _sr.sprite = _sprite[_mode];
                Attack();
                break;

            ///<summary>雪君出す時の行動</summary>
            case AttackPattern.Snow: // == 2
                _sr.sprite = _sprite[_mode];
                Attack();
                break;
        }
    }

    private void Attack()
    {
        if (!_isAttack)
        {
            _layerNum = _mode + 5;//デバックしやすいように変数に入れる
            SetLayer(_layerNum);//レイヤーを6，7にする
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
        }//一定時間たったら移動させる、レイヤーを0に戻す
    }

    /// <summary>ボスをレイヤー変更する</summary>
    /// <param name="num">レイヤーの番号</param>
    void SetLayer(int num)
    {
        gameObject.layer = num;
    }

    void IDamage.Damage()
    {
        _hp -= _damage;
        _soundManager.AudioPlay(_soundManager.AttackAudios[4]);
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
