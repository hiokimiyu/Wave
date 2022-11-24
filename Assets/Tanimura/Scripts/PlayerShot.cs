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
    [SerializeField] GameObject _gameManager;
    
   
    bool _isKaniCatch;

    int _rangeLV = 0;
    public int RangeLV { get => _rangeLV; set => _rangeLV = value; }
    /// <summary>ゲームマネージャーから攻撃の判定を受け取るための変数 </summary>
    GameManager _attackTypeJudge;
    VitalCapacity _healJudge;
    KaniCatch _kaniCatchJudge;
    

    void Start()
    {
        //あとでゲームマネージャーから何の攻撃を出すか受け取る
        _attackTypeJudge = _gameManager.GetComponent<GameManager>();
        _healJudge = gameObject.GetComponent<VitalCapacity>();
        _kaniCatchJudge = gameObject.GetComponent<KaniCatch>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (_isKaniCatch)
            {
                //投げる処理を書く
                _crabBullet.SetActive(false);

            }
            else if (_attackTypeJudge.Type == GameManager.AttackType.Normal)
            {
                //攻撃を飛ばす処理を書く(とりあえず音波を飛ばす処理だけ。ローテーションの値で左右を判定してどっちに飛ばすか決めている)
                Debug.Log("LeftClick");
                //音波の飛ばす処理、後でif文で切り替えれるようにする
                GameObject shot = Instantiate(_soundWave[_rangeLV]);
                shot.transform.position = this.gameObject.transform.position;
                if (this.gameObject.transform.localEulerAngles.y == 180)
                {
                    shot.GetComponent<SoundWave>().Dir = -1;
                    Debug.Log(shot.GetComponent<SoundWave>().Dir);
                }
            }

            //肺活量が足りているなら攻撃を出す
            if (_healJudge.VitalCapacityUse(_temperatureWaveCost))
            {
                //if(Flame)
                //自分の位置からマウスの位置に向かって温度波を出す
                GameObject shot = Instantiate(_flameWave[_rangeLV], gameObject.transform.position, Quaternion.identity);

                //if(Snow)
                //{
                //GameObject shot = Instantiate(_snowWave[_rangeLV], gameObject.transform.position, Quaternion.identity);
                //}
                var pos = Camera.main.WorldToScreenPoint(transform.localPosition);
                var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);
                shot.transform.localRotation = rotation;
                StartCoroutine(IsRecovery(0.5f));

            }


        }
        //攻撃切り替えの入力受付
        if (Input.GetButtonDown("Fire2"))
        {
            //攻撃切り替えの処理を後で書く
            Debug.Log("RightClick");
            _attackTypeJudge.AttackSwitch();
        }


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (_isKaniCatch ==false)
            {
                if(_kaniCatchJudge.IsKaniCatch())
                {
                    _crabBullet.SetActive(true);
                }
            }
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
}
