using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        //if the water panel gets too far off screen move it to the right of the screen
        if (transform.position.x < -45.6)
        {
            transform.position = new Vector3(47.6f, 0, 2);
        }
    }

}
