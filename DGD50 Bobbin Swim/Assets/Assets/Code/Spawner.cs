using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timer;
    public GameObject[] water;
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
            Instantiate(water[UnityEngine.Random.Range(0, 4)], new Vector3(69, 0, 2), Quaternion.identity);
            timer = 3f;
        }
    }
}
