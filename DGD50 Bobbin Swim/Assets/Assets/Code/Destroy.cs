using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //destroy water and enemies
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "water")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "enemy")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "coin")
        {
            Destroy(other.gameObject);
        }
    }
}
