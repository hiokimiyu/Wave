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
    [SerializeField] Slider _hpBar;
    /// <summary>地面の接触判定</summary>
    bool _isGround = true;//地面の接触判定の変数

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
        _rb.AddForce(Vector2.right * h * _speed, ForceMode2D.Force);
        //地面にいるときだけジャンプする
        if(Input.GetButtonDown("Jump")&&_isGround)
        {
            _rb.AddForce(Vector2.up  * _jumpPower, ForceMode2D.Impulse);
            _isGround = false;
        }
        //攻撃切り替えの入力受付
        if(Input.GetButtonDown("Fire2"))
        {
            //攻撃切り替えの処理を後で書く
            Debug.Log("LeftClick");
        }
    }

    //地面との接触判定の処理
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Ground")
        {
            _isGround = true;
        }
    }

    //ダメージを受ける処理
    public void Damage(int damage)
    {
        _playerHp -= damage;
        _hpBar.value = _playerHp;
    }

    //アイテムで回復するときの処理
    public void Heal(int heal)
    {
        _playerHp += heal;
        _hpBar.value = _playerHp;
    }



}
