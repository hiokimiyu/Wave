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
    [SerializeField] GameObject _gameManager;
    /// <summary>ゲームマネージャーから攻撃の判定を受け取るための変数 </summary>
    GameManager _attackTypeJudge;


    void Start()
    {
        //あとでゲームマネージャーから何の攻撃を出すか受け取る
        //_attackTypeJudge = _gameManager.GetComponent<GameManager>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //攻撃を飛ばす処理を書く(とりあえず音波を飛ばす処理だけ。ローテーションの値で左右を判定してどっちに飛ばすか決めている)
            Debug.Log("LeftClick");
            //音波の飛ばす処理、後でif文で切り替えれるようにする
            //GameObject shot =  Instantiate(_soundWave);
            //shot.transform.position = this.gameObject.transform.position;
            //if (this.gameObject.transform.localEulerAngles.y == 180)
            //{
            //    shot.GetComponent<SoundWave>().Dir = -1;
            //    Debug.Log(shot.GetComponent<SoundWave>()._dir);
            //}

            //自分の位置からマウスの位置に向かって温度波を出す
            GameObject shot = Instantiate(_flameWave[0],gameObject.transform.position,Quaternion.identity);
            var pos = Camera.main.WorldToScreenPoint(transform.localPosition);
            var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);
            shot.transform.localRotation = rotation;


        }
        //攻撃切り替えの入力受付
        if (Input.GetButtonDown("Fire2"))
        {
            //攻撃切り替えの処理を後で書く
            Debug.Log("RightClick");
        }
    }
}
