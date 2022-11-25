using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    [Tooltip("音波のプレハブ")]
    [SerializeField] GameObject[] _soundWave;
    [Tooltip("音波の消費肺活量")]
    [SerializeField] int _soundWaveCost;
    [Tooltip("熱波のプレハブ")]
    [SerializeField] GameObject[] _flameWave;
    [Tooltip("寒波のプレハブ")]
    [SerializeField] GameObject[] _snowWave;
    [Tooltip("温度波の消費肺活量")]
    [SerializeField] int _temperatureWaveCost;
    [Tooltip("衝撃波のプレハブ")]
    [SerializeField] GameObject[] _shockWave;
    [Tooltip("衝撃波の消費肺活量")]
    [SerializeField] int _shockWaveCost;
    [Tooltip("カニの弾の子オブジェクト")]
    [SerializeField] GameObject _crabBullet;
    [Tooltip("攻撃の判定を受け取るための変数")]
    [SerializeField] GameObject _gameManager;
    
   /// <summary>カニを追っているかどうかの判定</summary>
    bool _isKaniCatch;
    /// <summary>カニを追っているかどうかの判定のプロパティ</summary>
    public bool IsKaniCatch { get => _isKaniCatch; set => _isKaniCatch = value; }
    /// <summary>射程距離のレベル</summary>
    int _rangeLV = 0;
    /// <summary>射程距離のレベルのプロパティ</summary>
    public int RangeLV { get => _rangeLV; set => _rangeLV = value; }
    /// <summary>肺活量の判定のスクリプト</summary>
    VitalCapacity _healJudge;
    /// <summary>カニの接触判定のスクリプト</summary>
    KaniCatch _kaniCatchJudge;
    /// <summary>攻撃種類の判定のスクリプト</summary>
    GameManager _attackJudge;
    

    void Start()
    {
        _attackJudge = _gameManager.GetComponent<GameManager>();
        _healJudge = gameObject.GetComponent<VitalCapacity>();
        _kaniCatchJudge = gameObject.transform.GetChild(0).GetComponent<KaniCatch>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //カニを持っていたらそのまま飛ばす
            if (_isKaniCatch)
            {
                //投げる処理
                KaniShot();
                IsKaniCatch = false;
                //カニを投げた後にカニの表示を消す
                _kaniCatchJudge.KaniLost(transform.GetChild(0).gameObject);
                _crabBullet.GetComponent<SpriteRenderer>().enabled = false;
                //_crabBullet.SetActive(false);

            }
            //攻撃種類の判定,音波
            else if (_attackJudge.Strength == GameManager.AttackStrength.Normal)
            {
                //肺活量が足りているかの判定
                if (_healJudge.VitalCapacityUse(_soundWaveCost))
                {
                    //攻撃を飛ばす処理を書く(とりあえず音波を飛ばす処理だけ。ローテーションの値で左右を判定してどっちに飛ばすか決めている)
                    Debug.Log("LeftClick");
                    //音波の飛ばす処理
                    GameObject shot = Instantiate(_soundWave[_rangeLV]);
                    shot.transform.position = this.gameObject.transform.position;
                    StartCoroutine(IsRecovery(0.5f));
                    if (this.gameObject.transform.localEulerAngles.y == 180)
                    {
                        shot.GetComponent<SoundWave>().Dir = -1;
                        Debug.Log(shot.GetComponent<SoundWave>().Dir);
                    }
                }
            }
            //攻撃種類の判定,温度波
            else if(_attackJudge.Strength == GameManager.AttackStrength.Middle)
            {
                //肺活量が足りているかの判定
                if (_healJudge.VitalCapacityUse(_temperatureWaveCost))
                {
                    GameObject shot;
                    if (_attackJudge.Type == GameManager.AttackType.Warm)
                    {
                        //自分の位置からマウスの位置に向かって熱波を出す
                        shot = Instantiate(_flameWave[_rangeLV], gameObject.transform.position, Quaternion.identity);
                    }

                    else
                    {
                        //自分の位置からマウスの位置に向かって寒波を出す
                        shot = Instantiate(_snowWave[_rangeLV], gameObject.transform.position, Quaternion.identity);
                    }
                    var pos = Camera.main.WorldToScreenPoint(transform.localPosition);
                    var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);
                    shot.transform.localRotation = rotation;
                    StartCoroutine(IsRecovery(0.5f));
                }

            }
            //攻撃種類の判定,衝撃波
            else if(_attackJudge.Strength == GameManager.AttackStrength.PowerAttack)
            {
                if(_healJudge.VitalCapacityUse(_shockWaveCost))
                {
                    GameObject shot = Instantiate(_shockWave[_rangeLV], gameObject.transform.position, Quaternion.identity);
                    StartCoroutine(IsRecovery(0.5f));
                }
            }


        }
        //攻撃切り替えの入力受付
        if (Input.GetButtonDown("Fire2"))
        {
            //攻撃切り替えの処理を後で書く
            Debug.Log("RightClick");
            _attackJudge.AttackSwitch();
        }
    }

    /// <summary> 攻撃後少しだけ肺活量の回復を止めて、また再開する処理 </summary>
    /// <param name="RearGap"></param>
    /// <returns></returns>
    IEnumerator IsRecovery(float RearGap)
    {
        _healJudge.IsRecovery = false;
        yield return new WaitForSeconds(RearGap);
        _healJudge.IsRecovery = true;
        Debug.Log(_healJudge.IsRecovery);
    }

    /// <summary>カニを飛ばして、持っていないことにする</summary>
    public void KaniShot()
    {
        KaniBullet.Instantiate(_crabBullet, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        
    }
}
