using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    [SerializeField] GameObject _soundWave;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //�U�����΂�����������(�Ƃ肠�������g���΂����������B���[�e�[�V�����̒l�ō��E�𔻒肵�Ăǂ����ɔ�΂������߂Ă���)
            Debug.Log("LeftClick");
            GameObject shot =  Instantiate(_soundWave);
            shot.transform.position = this.gameObject.transform.position;
            if (this.gameObject.transform.localEulerAngles.y == 180)
            {
                shot.GetComponent<SoundWave>()._dir = -1;
                Debug.Log(shot.GetComponent<SoundWave>()._dir);
            }
            
        }
        //�U���؂�ւ��̓��͎�t
        if (Input.GetButtonDown("Fire2"))
        {
            //�U���؂�ւ��̏�������ŏ���
            Debug.Log("RightClick");
        }
    }
}
