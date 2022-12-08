using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A,D:移動
/// 左クリック:攻撃
/// 右クリック:攻撃の切り替え
/// Shift:カニ掴み
/// Space:ジャンプ
/// </summary>
public class PlayerMove : MonoBehaviour
{
    /// <summary>Rigidbodyの変数</summary>
    private Rigidbody2D _rb;
    [Tooltip("スピード")]
    [SerializeField] private float _speed;
    [Tooltip("ジャンプパワー")]
    [SerializeField] private float _jumpPower;
    [Tooltip("プレイヤーのHP")]
    [SerializeField] private int _playerHp;
    [Tooltip("プレイヤーの最大HP")]
    [SerializeField] private int _playerMaxHp;
    [Tooltip("プレイヤーがダメージを受けた時の無敵時間")]
    [SerializeField] private float _godModeTime;
    [Tooltip("プレイヤーのHPバー")]
    [SerializeField] private Slider _hpBar;
    [Tooltip("プレイヤーのアニメーション")]
    [SerializeField] private Animator _damageAnimation;

    private readonly string _groundTag = "Ground";
    /// <summary>地面の接触判定</summary>
    private bool _isGround = true;
    /// <summary>無敵時間判定の変数</summary>
    private bool _isGodMode = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        //HPバー(Slider)の設定
        _hpBar.maxValue = _playerMaxHp;
        _hpBar.value = _playerHp;
    }

    void Update()
    {
        //移動の処理
        float h = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(h * _speed, _rb.velocity.y);

        if(h != 0)
        {
            _damageAnimation.SetBool("IsWalking", true);
        }
        else
        {
            _damageAnimation.SetBool("IsWalking", false);
        }
        //地面にいるときだけジャンプする
        if (Input.GetButtonDown("Jump") && _isGround)
        {
            _rb.AddForce(Vector2.up  * _jumpPower, ForceMode2D.Impulse);
            _isGround = false;
        }

        //進行方向にプレイヤーの向きを変える処理(Transform.scale.x の±で切り替える)
        var localScale = gameObject.transform.localScale;
        if (h > 0)
        {
            localScale.x = Mathf.Abs(localScale.x);
            gameObject.transform.localScale = localScale;
        }
        else if (h < 0)
        {
            localScale.x = -Mathf.Abs(localScale.x);
            gameObject.transform.localScale = localScale;
        }
    }

    //地面との接触判定の処理
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(_groundTag))        
        {
            _isGround = true;
        }
    }

    //ダメージを受ける処理
    public void Damage(int damage)
    {
        if (_isGodMode == false)
        {
            _playerHp -= damage;
            _hpBar.value = _playerHp;
            if (_playerHp <= 0)
            {
                GameObject.Find("Managers").GetComponent<GameManager>().GameOver();
                Debug.Log("GameOverです");
            }
            StartCoroutine(GodMode());
            Debug.Log(_playerHp);
        }
    }

    //アイテムで回復するときの処理
    /// <summary>
    /// 回復アイテムをとったときに呼ぶ処理
    /// </summary>
    /// <param name="heal"> 回復量 </param>
    public void Heal(int heal)
    {
        _playerHp += heal;
        _hpBar.value = _playerHp;
    }

    //無敵時間の間アニメーションを動かしてダメージを受けない処理
    IEnumerator GodMode()
    {
        _isGodMode = true;
        _damageAnimation.SetBool("IsDamage", true);
        yield return new WaitForSeconds(_godModeTime);
        _damageAnimation.SetBool("IsDamage", false);
        _isGodMode = false;
    }
}
