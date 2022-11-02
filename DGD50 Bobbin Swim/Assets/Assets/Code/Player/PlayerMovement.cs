using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public int score;
    private int displayScore, gODisplayScore;
    public TextMeshProUGUI scoreText;
    public string gameover;
    public ParticleSystem bubbles;
    public bool InWater = true;

    public Timer T;
    //public bool inWater;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        displayScore = 0;
        bubbles = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
       // Vector2 vel = rb.velocity;

        //float rbVel = rb.velocity.y;
        //if(rbVel <= 5 && rbVel >= -20)
        //{
        //    this.transform.Rotate(0, 0, rb.velocity.y / 20);
        //}
        //Debug.Log(rbVel);
        //setting player pref of score and updating score text
        PlayerPrefs.SetInt("displayScore", score);
        if (score != displayScore)
        {
            displayScore = score;
            scoreText.text = displayScore.ToString();
        }

       

        //rb.velocity = vel;

    }

    private void FixedUpdate()
    {
        if (InWater)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rb.gravityScale = 0;
                rb.AddForce(Vector3.up * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
                this.transform.Rotate(0, 0, rb.velocity.y / 8);
            }
            else
            {
                rb.gravityScale = 0;
                rb.AddForce(Vector3.down * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
                this.transform.Rotate(0, 0, rb.velocity.y / 8);
            }
        }
        else
        {
            rb.gravityScale = 1;
        }
    }
    //player movement in water
    private void OnTriggerStay2D(Collider2D other)
    {
        //what the hell is this?? looks overcomplicated
        if (other.gameObject.CompareTag("water"))
        {
            InWater = true;
            

        }
        
    }
    //player movement out of water

    private void OnTriggerExit2D(Collider2D collision)
    {
        var main = bubbles.main;

        if (collision.gameObject.CompareTag("water"))
        {
            rb.gravityScale = 1f;
            //bubbles.Pause();
            main.maxParticles = 0;
            InWater = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //game over
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene(gameover);
        }
        if (collision.gameObject.CompareTag("gameOver"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene(gameover);
        }
        //collect coins and add score
        if (collision.gameObject.CompareTag("coin"))
        {
            score++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("bubble"))
        {
            T.time += 5;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var main = bubbles.main;
        if (other.gameObject.CompareTag("water"))
        {
            //bubbles.Play();
            main.maxParticles = 50;
            //inWater = true;
        }
    }
}
