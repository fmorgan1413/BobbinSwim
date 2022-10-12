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
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        displayScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
    }
    //player movement in water
    private void OnTriggerStay2D(Collider2D other)
    {
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
        if (other.gameObject.tag == "water")
        {
            rb.gravityScale = 1f;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
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
    }
}
