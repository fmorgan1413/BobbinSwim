using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //why would you spawn new water?? changed so that its 4 objects that just move around. dont use this, uncessary script
    public float timer;
    public GameObject water;
    // Start is called before the first frame update
    void Start()
    {
        timer = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //spawn water
    void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
        if(timer <= 0.0f)
        {
            Instantiate(water, new Vector3(0, 0, 2), Quaternion.identity);
            timer = 3f;
        }

       
    }
}
