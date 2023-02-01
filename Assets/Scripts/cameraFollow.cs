using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;
    Vector3 newPosition;

    void LateUpdate(){
        newPosition = target.position;
        newPosition.z = -10;
        transform.position = newPosition;
    }
}
