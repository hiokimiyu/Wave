using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボスのダメージ
/// </summary>
interface IBossDamage
{
    /// <summary>熱波の時のダメージ受けるとき</summary>
    void FlameDamage();
    ///<summary>寒波からのダメージ</summary>
    void SnowDamage();

}
