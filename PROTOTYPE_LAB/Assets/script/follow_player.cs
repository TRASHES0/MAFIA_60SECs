using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_player : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;  //º¸Á¤°ª

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
    }
}
