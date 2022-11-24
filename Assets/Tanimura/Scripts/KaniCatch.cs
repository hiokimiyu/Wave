using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaniCatch : MonoBehaviour
{
    [Tooltip("�J�j�̃^�O")]
    [SerializeField, TagName] string _crabTag;
    [SerializeField] float _maxCatchDistance = 2f;
    /// <summary>�J�j���L���b�`�\���ǂ������肷��</summary>
    bool _isCanKaniCatch;
    /// <summary>�J�j���L���b�`�\���ǂ������肷��v���p�e�B</summary>
    public bool IsCanKaniCatch { get => _isCanKaniCatch; set => _isCanKaniCatch = value; }


    void Start()
    {

    }


    void Update()
    {
        
    }

    public bool IsKaniCatch()
    {
        Ray ray = new Ray(gameObject.transform.position, this.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _maxCatchDistance))
        {
           if(hit.collider.gameObject.tag == _crabTag)
            {
                Destroy(hit.collider.gameObject);
                return true;
            }
           else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    
}
