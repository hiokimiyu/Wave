using UnityEngine;

public class RideOnOff : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //��ɂ̂鎞�Ɉꏏ�ɓ����Q�[���I�u�W�F�N�g�ǉ�
        GameObject empty = new();
        //�������Ɠ����Ƃ���ɏꏊ�����킹��
        empty.transform.parent = transform;
        //����Ă����I�u�W�F�N�g��������I�u�W�F�N�g�ɓ����
        collision.transform.parent = empty.transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //�e�q�֌W���Ȃ���
        collision.transform.parent = null;
        //������Q�[���I�u�W�F�N�g���擾���ď���
        GameObject empty = gameObject.transform.GetChild(0).gameObject;
        Destroy(empty);
    }
}
