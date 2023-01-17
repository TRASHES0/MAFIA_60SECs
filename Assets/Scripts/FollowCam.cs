using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform targetTr;
    private Transform camTr;
    
    [Range(2.0f, 20.0f)]
    public float distance = 10.0f;
    
    [Range(0.0f, 10.0f)]
    public float height = 2.0f;
    
    public float damping = 1.0f;
    
    public float targetOffset = 2.0f;
    
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        camTr = GetComponent<Transform>();
    }

    void LateUpdate()
    {
        Vector3 pos = targetTr.position
                      + (-targetTr.forward * distance + new Vector3 (5f,0,0))
                      + (Vector3.up * height + new Vector3(0,3f,0));
        
        camTr.position = Vector3.SmoothDamp(camTr.position, // 시작 위치
                                            pos,            // 목표 위치
                                            ref velocity,   // 현재 속도
                                            damping);       // 목표 위치까지 도달할 시간
                                            
        
        //camTr.LookAt(targetTr.position + (targetTr.up * targetOffset));
        //camTr.LookAt(targetTr.position);
    }
}