using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    [SerializeField] GameObject _soundWave;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //攻撃を飛ばす処理を書く(とりあえず音波を飛ばす処理だけ。ローテーションの値で左右を判定してどっちに飛ばすか決めている)
            Debug.Log("LeftClick");
            GameObject shot =  Instantiate(_soundWave);
            shot.transform.position = this.gameObject.transform.position;
            if (this.gameObject.transform.localEulerAngles.y == 180)
            {
                shot.GetComponent<SoundWave>()._dir = -1;
                Debug.Log(shot.GetComponent<SoundWave>()._dir);
            }
            
        }
        //攻撃切り替えの入力受付
        if (Input.GetButtonDown("Fire2"))
        {
            //攻撃切り替えの処理を後で書く
            Debug.Log("RightClick");
        }
    }
}
