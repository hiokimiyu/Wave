using UnityEngine;

public class AttackStatus : MonoBehaviour
{
    /// <summary> 攻撃の強さ </summary>
    protected AttackStrength _strength = AttackStrength.Normal;
    /// <summary> 攻撃の種類 </summary>
    private AttackType _type = AttackType.Cold;

    public AttackStrength Strength { get => _strength; set => _strength = value; }
    public AttackType Type { get => _type; set => _type = value; }


    /// <summary>
    /// 攻撃の切り替え
    /// PlayerShot -> Update -> if(.....("Fire2")) の部分で呼び出す
    /// UIの表示(現在の状態を可視化するため)
    /// </summary>
    public void AttackSwitch()
    {
        Debug.Log("Attack type switch");
        switch (_strength)
        {
            //現在の状態によって切り替える(順番に)
            //UI表示の処理を書く
            case AttackStrength.Normal:
                _strength = AttackStrength.Middle;
                //AttackType = "ちょっと強い";
                break;
            case AttackStrength.Middle:
                _strength = AttackStrength.PowerAttack;
                //AttackType = "衝撃波";
                break;
            case AttackStrength.PowerAttack:
                _strength = AttackStrength.Normal;
                //AttackType = "音波(普通)";
                break;
        }
    }

    /// <summary> 攻撃の強さ </summary>
    public enum AttackStrength
    {
        /// <summary> 音波(通常) </summary>
        Normal,
        /// <summary> ちょっと強い </summary>
        Middle,
        /// <summary> 衝撃波 </summary>
        PowerAttack,
    }

    /// <summary> 攻撃の種類(寒暖) </summary>
    public enum AttackType
    {
        /// <summary> 寒波 </summary>
        Cold,
        /// <summary> 熱波 </summary>
        Warm,
    }
}
