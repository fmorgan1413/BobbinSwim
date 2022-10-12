using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float time, minutes, seconds;
    public TextMeshProUGUI timeText;
    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
        minutes = Mathf.FloorToInt(time / 60);
        seconds = Mathf.FloorToInt(time % 60);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("displayTime", time);
    }
    void FixedUpdate()
    {
        time += Time.deltaTime;
        DisplayTime(time);
    }
    void DisplayTime(float timeDisplayed)
    {
        float minutes = Mathf.FloorToInt(timeDisplayed / 60);
        float seconds = Mathf.FloorToInt(timeDisplayed % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
