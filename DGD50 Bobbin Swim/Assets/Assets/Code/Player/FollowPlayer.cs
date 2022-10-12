using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;

    public ParticleSystem bubbles;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        this.transform.position = desiredPosition;
    }

}
