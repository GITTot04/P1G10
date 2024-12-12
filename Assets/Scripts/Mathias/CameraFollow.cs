using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed;
    public Transform target;

    void FixedUpdate()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, -10);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed*Time.deltaTime);
    }
}
