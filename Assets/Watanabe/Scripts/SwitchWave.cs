using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 寒波、熱波を切り替える
/// </summary>
public class SwitchWave : MonoBehaviour
{
    /// <summary> 寒波か、熱波か(false...寒波, true...熱波) </summary>
    public bool IsWarm { get; set; }

    void Switch()
    {
        //切り替えオブジェクトに触れた時、寒波、熱波を切り替える
        //寒波、熱波の切り替え(false...寒波, true...熱波)
        IsWarm = IsWarm == true ? false : true;
        Debug.Log(IsWarm);
        //playerに、現在の攻撃の状態を保存しておく変数を用意してもらう
    }
}
