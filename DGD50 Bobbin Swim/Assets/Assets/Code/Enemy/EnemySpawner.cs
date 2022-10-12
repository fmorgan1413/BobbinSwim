using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float timer;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        //set timer to high amount so enemies don't keep spawning
        timer = 10;
    }

    // Update is called once per frame
    void Update()
    {

    }
    //spawn enemy
    void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
        //spawning enemies when timer is up
        if (timer <= 0.0f)
        {
            Instantiate(enemy, new Vector3(55, UnityEngine.Random.Range(-5, 5), 2), Quaternion.identity);
            //set timer high so enemies don't keep spawning
            timer = 10;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //setting timer to a random amount within the confines of the water
        if (other.gameObject.tag == "water")
        {
            timer = UnityEngine.Random.Range(0.25f, 2.4f);
           
        }
    }
}
