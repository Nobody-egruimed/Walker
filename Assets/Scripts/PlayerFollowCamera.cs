using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowCamera : MonoBehaviour
{
    Vector3 CameraPosition = Vector3.zero;
    public GameObject followTarget; 
    public float followSpeed = 0f;

    void Start()
    {
        CameraPosition = followTarget.transform.position - transform.position;
        Debug.Log(CameraPosition);
    }
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            followTarget.transform.position - CameraPosition,
            Time.deltaTime * followSpeed
        );
    }
}
