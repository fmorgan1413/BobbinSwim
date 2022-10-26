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
        //Debug.Log(coll)
    }
    //destroy water and enemies

    //why are so many of these triggers?

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collision = get

        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("bubble"))
        {
            Destroy(collision.gameObject);
        }
    }
}
