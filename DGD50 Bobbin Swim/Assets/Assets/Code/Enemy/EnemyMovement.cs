using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //literally the exact same as the coin movement. why bother having multiple scripts? just put the other one on all the objects
    //redundant
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
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "water")
        {
            this.transform.SetParent(other.gameObject.transform, true);
        }
    }
}
