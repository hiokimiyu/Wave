using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Š¦”gA”M”g‚ğØ‚è‘Ö‚¦‚é
/// </summary>
public class SwitchWave : MonoBehaviour
{
    /// <summary> Š¦”g‚©A”M”g‚©(false...Š¦”g, true...”M”g) </summary>
    public bool IsWarm { get; set; }

    void Switch()
    {
        //Ø‚è‘Ö‚¦ƒIƒuƒWƒFƒNƒg‚ÉG‚ê‚½AŠ¦”gA”M”g‚ğØ‚è‘Ö‚¦‚é
        //Š¦”gA”M”g‚ÌØ‚è‘Ö‚¦(false...Š¦”g, true...”M”g)
        IsWarm = IsWarm == true ? false : true;
        Debug.Log(IsWarm);
        //player‚ÉAŒ»İ‚ÌUŒ‚‚Ìó‘Ô‚ğ•Û‘¶‚µ‚Ä‚¨‚­•Ï”‚ğ—pˆÓ‚µ‚Ä‚à‚ç‚¤
    }
}
