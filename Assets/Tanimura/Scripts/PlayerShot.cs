using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //攻撃を飛ばす処理を書く
            Debug.Log("LeftClick");
        }
        //攻撃切り替えの入力受付
        if (Input.GetButtonDown("Fire2"))
        {
            //攻撃切り替えの処理を後で書く
            Debug.Log("RightClick");
        }
    }
}
