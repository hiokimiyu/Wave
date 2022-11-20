using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //UŒ‚‚ğ”ò‚Î‚·ˆ—‚ğ‘‚­
            Debug.Log("LeftClick");
        }
        //UŒ‚Ø‚è‘Ö‚¦‚Ì“ü—Íó•t
        if (Input.GetButtonDown("Fire2"))
        {
            //UŒ‚Ø‚è‘Ö‚¦‚Ìˆ—‚ğŒã‚Å‘‚­
            Debug.Log("RightClick");
        }
    }
}
