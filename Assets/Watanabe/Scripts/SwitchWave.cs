using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Š¦”gA”M”g‚ğØ‚è‘Ö‚¦‚é
/// </summary>
public class SwitchWave : MonoBehaviour
{
    [Tooltip("Ø‚è‘Ö‚¦ƒIƒuƒWƒFƒNƒg‚É“ü‚Á‚Ä‚«‚½‚Ì‚ªPlayer‚©‚Ç‚¤‚©")]
    [SerializeField, TagName] string _enterTag;

    /// <summary> Š¦”g‚©A”M”g‚©(false...Š¦”g, true...”M”g) </summary>
    public bool IsWarm { get; set; }

    void Switch()
    {
        //Ø‚è‘Ö‚¦ƒIƒuƒWƒFƒNƒg‚ÉG‚ê‚½‚ÉŠ¦”gA”M”g‚ğØ‚è‘Ö‚¦‚é
        //Š¦”gA”M”g‚ÌØ‚è‘Ö‚¦(false...Š¦”g, true...”M”g)
        IsWarm = IsWarm == true ? false : true;
        Debug.Log(IsWarm);
        //player‚ÉAŒ»İ‚ÌUŒ‚‚Ìó‘Ô‚ğ•Û‘¶‚µ‚Ä‚¨‚­•Ï”‚ğ—pˆÓ‚µ‚Ä‚à‚ç‚¤
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Ø‚è‘Ö‚¦‚Ü‚·");
        //Ø‚è‘Ö‚¦ƒIƒuƒWƒFƒNƒg‚É“ü‚Á‚Ä‚«‚½‚Ì‚ªPlayer‚¾‚Á‚½‚ç
        if (col.tag == _enterTag)
        {
            //Š¦”gA”M”g‚ğØ‚è‘Ö‚¦‚é
            Switch();
        }
    }
}
