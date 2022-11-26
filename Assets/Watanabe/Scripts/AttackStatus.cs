using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStatus : MonoBehaviour
{
    /// <summary> 攻撃の強さ </summary>
    AttackStrength _strength = AttackStrength.Normal;
    /// <summary> 攻撃の種類 </summary>
    AttackType _type = AttackType.Cold;

    /// <summary> 攻撃の強さ </summary>
    public AttackStrength Strength { get => _strength; set => _strength = value; }
    public AttackType Type { get => _type; set => _type = value; }


    /// <summary>
    /// 攻撃の切り替え
    /// PlayerShot -> Update -> if(.....("Fire2")) の部分で呼び出す
    /// UIの表示(現在の状態を可視化するため)
    /// </summary>
    public void AttackSwitch()
    {
        //現在の状態によって切り替える(順番に)
        //UI表示の処理を書く
        if (Strength == AttackStrength.Normal)
        {
            Strength = AttackStrength.Middle;
            AttackType = "ちょっと強い";
        }
        else if (Strength == AttackStrength.Middle)
        {
            if (Type == AttackType.Cold)
                Type = AttackType.Warm;
            else
                Type = AttackType.Cold;

            Strength = AttackStrength.PowerAttack;
            AttackType = "衝撃波";
        }
        else if (Strength == AttackStrength.PowerAttack)
        {
            Strength = AttackStrength.Normal;
            AttackType = "音波(普通)";
        }
    }

    /// <summary> 攻撃の強さ </summary>
    public enum AttackStrength
    {
        /// <summary> 音波(通常) </summary>
        Normal,
        /// <summary> ちょっと強いやつ </summary>
        Middle,
        /// <summary> 衝撃波 </summary>
        PowerAttack,
    }

    /// <summary> 攻撃の種類 </summary>
    public enum AttackType
    {
        /// <summary> 寒波 </summary>
        Cold,
        /// <summary> 熱波 </summary>
        Warm,
    }
}
