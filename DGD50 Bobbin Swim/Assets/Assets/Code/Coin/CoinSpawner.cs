using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    //why have 3 different spawners?? add all spawning objects to this
    //public float timer;
    public GameObject coin;
    public GameObject bubble;
    public GameObject enemy;

    public Dictionary<GameObject, float> ObjectTimers = new Dictionary<GameObject, float>();
    // Start is called before the first frame update
    void Start()
    {
        //set timer to high amount so coins don't keep spawning
        //timer = Random.Range(3, 10);
        ObjectTimers.Add(coin, Random.Range(1f, 5f));
        ObjectTimers.Add(bubble, Random.Range(1f, 5f));
        ObjectTimers.Add(enemy, Random.Range(1f, 5f));
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
        SpawnThing(coin, -13.5f, -9.6f);
        SpawnThing(bubble, 9.1f, 13.3f);
        SpawnThing(enemy, -6.3f, 13.3f);
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

    public void SpawnThing(GameObject g, float max, float min)
    {
        ObjectTimers[g] -= Time.fixedDeltaTime;
        if (ObjectTimers[g] <= 0.0f)
        {
            Instantiate(g, new Vector3(55, Random.Range(min, max), 1), Quaternion.identity);
            ObjectTimers[g] = Random.Range(1f, 5f);
        }
    }
}
