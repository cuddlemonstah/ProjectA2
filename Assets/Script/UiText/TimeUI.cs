using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour
{
    EnemySpawner spawn;
    private float timer;
    public bool gameIsPaused;
    public Text text;
    private string firstMinute;
    private string secondMinute;
    private string separator = ":";
    private string firstSecond;
    private string secondSecond;

    void Start()
    {
        spawn = FindObjectOfType<EnemySpawner>();
        resetTimer();
    }
    void FixedUpdate()
    {
        if (!gameIsPaused)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Time.timeScale = 0;
            timer += Time.deltaTime;
        }

        UpdateTimerDisplay(timer);
    }
    private void resetTimer()
    {
        timer = 0f;
    }
    private void UpdateTimerDisplay(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds);
        firstMinute = currentTime[0].ToString();
        secondMinute = currentTime[1].ToString();
        firstSecond = currentTime[2].ToString();
        secondSecond = currentTime[3].ToString();
        text.text = firstMinute + secondMinute + separator + firstSecond + secondSecond;
        spawn.setTimeMinutes(minutes, seconds);
    }

}
