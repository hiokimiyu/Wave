using UnityEngine;

/// <summary>
/// Š¦”gA”M”g‚ğØ‚è‘Ö‚¦‚é
/// </summary>
public class SwitchWave : MonoBehaviour
{
    private readonly string _enterTag = "Player";
    private AttackStatus _status;

    private void Start()
    {
        _status = GetComponent<AttackStatus>();
    }

    void Switch()
    {
        //Ø‚è‘Ö‚¦ƒIƒuƒWƒFƒNƒg‚ÉG‚ê‚½‚ÉŠ¦”gA”M”g‚ğØ‚è‘Ö‚¦‚é
        if (_status.Type == AttackStatus.AttackType.Cold)
        {
            _status.Type = AttackStatus.AttackType.Warm;
        }
        else if (_status.Type == AttackStatus.AttackType.Warm)
        {
            _status.Type = AttackStatus.AttackType.Cold;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Ø‚è‘Ö‚¦‚Ü‚·");
        //Ø‚è‘Ö‚¦ƒIƒuƒWƒFƒNƒg‚É“ü‚Á‚Ä‚«‚½‚Ì‚ªPlayer‚¾‚Á‚½‚ç
        if (col.CompareTag(_enterTag))
        {
            //Š¦”gA”M”g‚ğØ‚è‘Ö‚¦‚é
            Switch();
        }
    }
}
