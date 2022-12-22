using UnityEngine;

public class BossMove : MonoBehaviour, IDamage
{
    [Tooltip("出現させるエネミー")]
    [SerializeField] private GameObject[] _enemy = new GameObject[3];
    [Tooltip("エネミーを出すところ")]
    [SerializeField] private Transform _spawnPos;
    [SerializeField] private Sprite[] _sprite = new Sprite[3];
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private SoundManager _soundManager;
    //ここから上はSerializeする必要がある

    [Range(0, 100)]
    [SerializeField] private float _hp = 10f;
    [Tooltip("強くなる時の残りHP")]
    [SerializeField] private int _powerUpHp = 4;
    [Tooltip("止まった所から移動するまでの時間")]
    [Range(1, 10)]
    [SerializeField] private float _moveTime = 3f;

    /// <summary> 強くなるときにマイナスする止まる時間 </summary>
    private readonly float _reduceTime = 2f;
    /// <summary> あたえるダメージ </summary>
    private readonly float _damage = 1;
    /// <summary> 円移動スピード </summary>
    private readonly float _circleSpeed = 1f;
    /// <summary> 敵を出すときに止まる時間 </summary>
    private float _stopTime = 3f;
    /// <summary> 円の半径 </summary>
    private readonly float _circleRadius = 5f;
    /// <summary>横移動させるためのタイマー</summary>
    private float _time = 0;
    /// <summary>モード切り替えに対応する敵を出すための数字</summary>
    private int _mode = 0;
    /// <summary>出したエネミーをカウントする</summary>
    private int _enemyCount = 0;
    /// <summary>攻撃したかどうか</summary>
    private bool _isAttack;
    /// <summary>最初の自分の位置を入れておく</summary>
    private Vector2 _startPos;
    /// <summary>スプライト</summary>
    private SpriteRenderer _sr;

    [Header("テスト用")]
    [Tooltip("何体出すか")]
    [SerializeField] private int _enemyNum;
    /// <summary> 自分の行動 </summary>
    private AttackPattern _attackPattern = AttackPattern.Normal;
    /// <summary>モード切替や移動間隔はかるタイマー</summary>
    private float _timer = 0;
    /// <summary> レイヤーの番号 </summary>
    private int _layerNum = 0;
    /// <summary> 行動したかどうか </summary>
    private bool _isMode = false;
    /// <summary> パワーアップしたか </summary>
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
            case AttackPattern.Normal:

                //自分のいるところ
                Vector2 pos = transform.position;
                //Θを求めてるはず
                float theta = _circleSpeed * _time * Mathf.PI;

                _sr.sprite = _sprite[_mode];
                //cosΘ * 半径 でｘを求めてる
                //自分の最初の位置から動かすためプラスする、端から始めるため半径をマイナス
                pos.x = Mathf.Cos(theta) * _circleRadius + _startPos.x - _circleRadius;
                pos.y = Mathf.Sin(theta) * _circleRadius;
                _time += Time.deltaTime;
                transform.position = pos;

                if (_enemyCount <= _enemyNum)
                {
                    Spawn();
                }
                break;

            /// <summary> 炎(雪)君出す時の行動 </summary>
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
            _layerNum = _mode + 5; //デバックしやすいように変数に入れる
            SetLayer(_layerNum); //レイヤーを6，7にする
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
}
