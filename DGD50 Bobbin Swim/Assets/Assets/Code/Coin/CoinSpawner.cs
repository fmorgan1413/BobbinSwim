using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    //why have 3 different spawners?? add all spawning objects to this
    public float timer;
    public GameObject coin;
    public GameObject bubble;

    public Dictionary<GameObject, float> ObjectTimers = new Dictionary<GameObject, float>();
    // Start is called before the first frame update
    void Start()
    {
        //set timer to high amount so coins don't keep spawning
        timer = Random.Range(3, 10);
        ObjectTimers.Add(coin, Random.Range(3, 10));
        ObjectTimers.Add(bubble, Random.Range(3, 10));
        //ObjectTimers.Add(coin, Random.Range(3, 10));
    }

    // Update is called once per frame
    void Update()
    {

    }
    //spawn enemy
    void FixedUpdate()
    {
        
        //timer -= Time.fixedDeltaTime;
        SpawnThing(coin);
        SpawnThing(bubble);
        //spawning coins when timer is up
       // if (timer <= 0.0f)
      //  {
            //Instantiate(coin, new Vector3(55, Random.Range(-5, 5), 1), Quaternion.identity);
            //Instantiate(bubble, new Vector3(55, Random.Range(-5, 5), 1), Quaternion.identity);
            //set timer high so coins don't keep spawning
            //timer = Random.Range(3, 10);
       // }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //setting timer to a random amount within the confines of the water
        if (other.gameObject.tag == "water")
        {
            //timer = UnityEngine.Random.Range(0.25f, 2.4f);

        }
    }

    public void SpawnThing(GameObject g)
    {
        ObjectTimers[g] -= Time.fixedDeltaTime;
        if (ObjectTimers[g] <= 0.0f)
        {
            Instantiate(g, new Vector3(55, Random.Range(-5, 5), 1), Quaternion.identity);
            ObjectTimers[g] = Random.Range(3, 10);
        }
    }
}
