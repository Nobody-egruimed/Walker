using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowCamera : MonoBehaviour
{
    Vector3 CameraPosition = Vector3.zero;
    public GameObject followTarget; 
    public float followSpeed = 0f;
    void start()
    {
        CameraPosition = followTarget.transform.position - transform.position;
    }
    void Lateupdaete()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            followTarget.transform.position - CameraPosition,
            Time.deltaTime * followSpeed
        );
    }
}
