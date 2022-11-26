using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStatus : MonoBehaviour
{
    /// <summary> UŒ‚‚Ì‹­‚³ </summary>
    AttackStrength _strength = AttackStrength.Normal;
    /// <summary> UŒ‚‚Ìí—Ş </summary>
    AttackType _type = AttackType.Cold;

    /// <summary> UŒ‚‚Ì‹­‚³ </summary>
    public AttackStrength Strength { get => _strength; set => _strength = value; }
    public AttackType Type { get => _type; set => _type = value; }


    /// <summary>
    /// UŒ‚‚ÌØ‚è‘Ö‚¦
    /// PlayerShot -> Update -> if(.....("Fire2")) ‚Ì•”•ª‚ÅŒÄ‚Ño‚·
    /// UI‚Ì•\¦(Œ»İ‚Ìó‘Ô‚ğ‰Â‹‰»‚·‚é‚½‚ß)
    /// </summary>
    public void AttackSwitch()
    {
        //Œ»İ‚Ìó‘Ô‚É‚æ‚Á‚ÄØ‚è‘Ö‚¦‚é(‡”Ô‚É)
        //UI•\¦‚Ìˆ—‚ğ‘‚­
        if (Strength == AttackStrength.Normal)
        {
            Strength = AttackStrength.Middle;
            AttackType = "‚¿‚å‚Á‚Æ‹­‚¢";
        }
        else if (Strength == AttackStrength.Middle)
        {
            if (Type == AttackType.Cold)
                Type = AttackType.Warm;
            else
                Type = AttackType.Cold;

            Strength = AttackStrength.PowerAttack;
            AttackType = "ÕŒ‚”g";
        }
        else if (Strength == AttackStrength.PowerAttack)
        {
            Strength = AttackStrength.Normal;
            AttackType = "‰¹”g(•’Ê)";
        }
    }

    /// <summary> UŒ‚‚Ì‹­‚³ </summary>
    public enum AttackStrength
    {
        /// <summary> ‰¹”g(’Êí) </summary>
        Normal,
        /// <summary> ‚¿‚å‚Á‚Æ‹­‚¢‚â‚Â </summary>
        Middle,
        /// <summary> ÕŒ‚”g </summary>
        PowerAttack,
    }

    /// <summary> UŒ‚‚Ìí—Ş </summary>
    public enum AttackType
    {
        /// <summary> Š¦”g </summary>
        Cold,
        /// <summary> ”M”g </summary>
        Warm,
    }
}
