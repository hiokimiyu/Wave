using UnityEngine;

public class RideOnOff : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //上にのる時に一緒に動くゲームオブジェクト追加
        GameObject empty = new();
        //動く床と同じところに場所を合わせる
        empty.transform.parent = transform;
        //乗ってきたオブジェクトを作ったオブジェクトに入れる
        collision.transform.parent = empty.transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //親子関係をなくす
        collision.transform.parent = null;
        //作ったゲームオブジェクトを取得して消す
        GameObject empty = gameObject.transform.GetChild(0).gameObject;
        Destroy(empty);
    }
}
