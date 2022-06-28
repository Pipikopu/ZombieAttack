using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    private int day;
    private int hour;
    private int minute;
    public float oneMinInSec;
    public Text clock;
    private string minuteString;
    private string hourString;
    private string dayString;

    public GameObject nextDayText;

    // Start is called before the first frame update
    void Start()
    {
        day = 0;
        hour = 0;
        minute = 0;
        StartCoroutine(runClock());
        nextDayText.GetComponent<Animator>().enabled = false;
    }

    IEnumerator runClock()
    {
        while (true)
        {
            yield return new WaitForSeconds(oneMinInSec);
            minute += 1;
            if (minute == 60)
            {
                hour += 1;
                minute = 0;
            }

            if (hour == 4)
            {
                day += 1;
                hour = 0;
                playAnimation();
                LevelManager.instance.nextLevel();
            }

            if (minute < 10)
            {
                minuteString = "0" + minute.ToString();
            }
            else
            {
                minuteString = minute.ToString();
            }

            if (hour < 10)
            {
                hourString = "0" + hour.ToString();
            }
            else
            {
                hourString = hour.ToString();
            }

            clock.text = $"Day {day}: {hourString}h{minuteString}";
        }
    }

    public void playAnimation()
    {
        nextDayText.GetComponent<Animator>().enabled = true;
        nextDayText.GetComponent<Animator>().Play(0);
    }
}
