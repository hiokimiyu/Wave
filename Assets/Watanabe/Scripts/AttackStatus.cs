using UnityEngine;

public class AttackStatus : MonoBehaviour
{
    /// <summary> UŒ‚‚Ì‹­‚³ </summary>
    protected AttackStrength _strength = AttackStrength.Normal;
    /// <summary> UŒ‚‚Ìí—Ş </summary>
    private AttackType _type = AttackType.Cold;

    public AttackStrength Strength { get => _strength; set => _strength = value; }
    public AttackType Type { get => _type; set => _type = value; }


    /// <summary>
    /// UŒ‚‚ÌØ‚è‘Ö‚¦
    /// PlayerShot -> Update -> if(.....("Fire2")) ‚Ì•”•ª‚ÅŒÄ‚Ño‚·
    /// UI‚Ì•\¦(Œ»İ‚Ìó‘Ô‚ğ‰Â‹‰»‚·‚é‚½‚ß)
    /// </summary>
    public void AttackSwitch()
    {
        Debug.Log("Attack type switch");
        switch (_strength)
        {
            //Œ»İ‚Ìó‘Ô‚É‚æ‚Á‚ÄØ‚è‘Ö‚¦‚é(‡”Ô‚É)
            //UI•\¦‚Ìˆ—‚ğ‘‚­
            case AttackStrength.Normal:
                _strength = AttackStrength.Middle;
                //AttackType = "‚¿‚å‚Á‚Æ‹­‚¢";
                break;
            case AttackStrength.Middle:
                _strength = AttackStrength.PowerAttack;
                //AttackType = "ÕŒ‚”g";
                break;
            case AttackStrength.PowerAttack:
                _strength = AttackStrength.Normal;
                //AttackType = "‰¹”g(•’Ê)";
                break;
        }
    }

    /// <summary> UŒ‚‚Ì‹­‚³ </summary>
    public enum AttackStrength
    {
        /// <summary> ‰¹”g(’Êí) </summary>
        Normal,
        /// <summary> ‚¿‚å‚Á‚Æ‹­‚¢ </summary>
        Middle,
        /// <summary> ÕŒ‚”g </summary>
        PowerAttack,
    }

    /// <summary> UŒ‚‚Ìí—Ş(Š¦’g) </summary>
    public enum AttackType
    {
        /// <summary> Š¦”g </summary>
        Cold,
        /// <summary> ”M”g </summary>
        Warm,
    }
}
