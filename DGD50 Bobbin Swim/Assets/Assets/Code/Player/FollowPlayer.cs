using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // why would you use a script to do this instead of just making the bubble particles a child of the whale?? not gonna delete anything but dont use this
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
