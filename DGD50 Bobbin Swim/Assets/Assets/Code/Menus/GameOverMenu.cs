using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public TextMeshProUGUI timeText, scoreText;
    public float displayTime, minutes, seconds;
    public int displayScore;
    public string mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        //minutes = Mathf.FloorToInt(displayTime / 60);
        //seconds = Mathf.FloorToInt(displayTime % 60);
        //displayTime = PlayerPrefs.GetFloat("displayTime");
        displayScore = PlayerPrefs.GetInt("displayScore");
    }

    // Update is called once per frame
    void Update()
    {
        //DisplayTime(displayTime);
        scoreText.text = displayScore.ToString();
    }
    void DisplayTime(float timeDisplayed)
    {
        //float minutes = Mathf.FloorToInt(timeDisplayed / 60);
        //float seconds = Mathf.FloorToInt(timeDisplayed % 60);
        timeText.text = displayTime.ToString(string.Format("{0:00}:{1:00}", minutes, seconds));
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
