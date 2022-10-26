using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailHittingWater : MonoBehaviour
{
    //useless script moved to player movement
    public ParticleSystem bubbles;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "water")
        {
            bubbles.Play();
            Debug.Log("working");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "water")
        {
            Debug.Log("paused");
            bubbles.Pause();
        }
    }
}
