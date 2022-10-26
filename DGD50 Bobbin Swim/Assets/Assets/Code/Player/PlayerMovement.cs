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
    public bool inWater;

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
    //player movement in water
    private void OnTriggerStay2D(Collider2D other)
    {
        //what the hell is this?? looks overcomplicated
        if (other.gameObject.tag == "water")
        {

            if (Input.GetKey(KeyCode.Space))
            {
                rb.gravityScale = 0;
                rb.AddForce(Vector3.down * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
                this.transform.Rotate(0, 0, rb.velocity.y / 8);
            }
            else
            {
                rb.gravityScale = 0;
                rb.AddForce(Vector3.up * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
                this.transform.Rotate(0, 0, rb.velocity.y / 8);
            }
        }
        else
        {
            rb.gravityScale = 1;
        }
    }
    //player movement out of water
    private void OnTriggerExit2D(Collider2D other)
    {
        var main = bubbles.main;

        if (other.gameObject.tag == "water")
        {
            rb.gravityScale = 1f;
            //bubbles.Pause();
            main.maxParticles = 0;
            inWater = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        var main = bubbles.main;
        //game over
        if(other.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(gameover);
        }
        if (other.gameObject.tag == "gameOver")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(gameover);
        }
        //collect coins and add score
        if (other.gameObject.tag == "coin")
        {
            score++;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "water")
        {
            //bubbles.Play();
            main.maxParticles = 50;
            inWater = true;
        }
    }
}
