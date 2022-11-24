using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RideOnOff : MonoBehaviour
{
    /// <summary>èÊÇ¡ÇƒÇ¢ÇÈÇ©Ç¢Ç»Ç¢Ç©îªíË</summary>
    bool _isRide;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isRide = true;
        GameObject _empty = new GameObject();
        _empty.transform.parent = transform;
        collision.transform.parent = _empty.transform;
        _empty.name = "empty";
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isRide = false;
        collision.transform.parent = null;
        GameObject _empty = gameObject.transform.GetChild(0).gameObject;
        Destroy(_empty);
    }
}
