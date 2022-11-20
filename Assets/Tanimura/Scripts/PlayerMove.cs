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
    Rigidbody2D _rb;
    [Tooltip("スピード")]
    [SerializeField] float _speed;//プレイヤーのスピード
    [Tooltip("ジャンプパワー")]
    [SerializeField] float _jumpPower;//プレイヤーのジャンプパワー
    [Tooltip("プレイヤーのHP")]
    [SerializeField] int _playerHp;//プレイヤーのHP
    [Tooltip("プレイヤーの最大HP")]
    [SerializeField] int _playerMaxHp;
    [Tooltip("プレイヤーの肺活量")]
    [SerializeField] float _vitalCapacity;//プレイヤーの肺活量
    [Tooltip("プレイヤーがダメージを受けた時の無敵時間")]
    [SerializeField] float _godModeTime;
    [Tooltip("プレイヤーのHPバー")]
    [SerializeField] Slider _hpBar;
    [Tooltip("プレイヤーのアニメーション")]
    [SerializeField] Animator _damageAnimation;
    [Tooltip("Groundタグ")]
    [SerializeField, TagName] string _groundTag;
    
    /// <summary>地面の接触判定</summary>
    bool _isGround = true;//地面の接触判定の変数
    /// <summary>無敵時間判定の変数</summary>
    bool _isGodMode = false;

    /// <summary>プレイヤーのHP</summary>
    public int PlayerHp { get => _playerHp; set => _playerHp = value; }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        //HPバーの設定
        _hpBar.maxValue = _playerMaxHp;
        _hpBar.value = _playerHp;
    }

    void Update()
    {
        //移動の処理
        float h = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(h, _rb.velocity.y);
        //地面にいるときだけジャンプする
        if (Input.GetButtonDown("Jump")　&& _isGround)
        {
            _rb.AddForce(Vector2.up  * _jumpPower, ForceMode2D.Impulse);
            _isGround = false;
        }
        
        //進行方向にプレイヤーの向きを変える処理
        transform.eulerAngles = h < 0 ? new Vector3(0, 180, 0) : new Vector3(0, 0, 0);
    }
        

    //地面との接触判定の処理
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == _groundTag)
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
            StartCoroutine(GodMode());
        }
    }

    //アイテムで回復するときの処理
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
