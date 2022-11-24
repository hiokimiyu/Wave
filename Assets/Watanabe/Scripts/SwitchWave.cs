using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 寒波、熱波を切り替える
/// </summary>
public class SwitchWave : MonoBehaviour
{
    [Tooltip("切り替えオブジェクトに入ってきたのがPlayerかどうか")]
    [SerializeField, TagName] string _enterTag;
    [Tooltip("GameManager(切り替え用)")]
    [SerializeField] GameManager _manager;

    void Switch()
    {
        //切り替えオブジェクトに触れた時に寒波、熱波を切り替える
        if (_manager.Type == GameManager.AttackType.Cold)
        {
            _manager.Type = GameManager.AttackType.Warm;
        }
        else
        {
            _manager.Type = GameManager.AttackType.Cold;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("切り替えます");
        //切り替えオブジェクトに入ってきたのがPlayerだったら
        if (col.tag == _enterTag)
        {
            //寒波、熱波を切り替える
            Switch();
        }
    }
}
