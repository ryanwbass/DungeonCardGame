using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject target;     
    
    public int offset;         

    void LateUpdate()
    {
        this.transform.position = target.transform.position + new Vector3(0, 0, offset);
    }

    public void SetTarget(GameObject target, int offset)
    {
        this.target = target;
        SetOffset(offset);
    }

    public void SetOffset(int offset)
    {
        this.offset = offset;
    }
}
