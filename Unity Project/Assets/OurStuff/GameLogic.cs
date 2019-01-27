using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public const float timeUntilClose = 60;
    public GameObject keys = null;
    public GameObject watch = null;

    private float timeLeft = 0;
    private Text watchDisplayText;

    void Start()
    {
        Reset();
    }
    
    void Update()
    {
        timeLeft -= Time.deltaTime;

        UpdateWatchDisplay();

        if (timeLeft < 0)
        {
            GameOver();
        }
    }

    private void Reset()
    {
        timeLeft = timeUntilClose;
    }

    private void GameOver()
    {

    }

    public void UpdateWatchDisplay()
    {
        if (watchDisplayText == null)
        {
            var watchDisplayObject = GameObject.FindWithTag("WatchText");
            watchDisplayText = watchDisplayObject.GetComponent<Text>();
        }

        int timeInteger = (int)Mathf.Floor(timeLeft);
        int secs = timeInteger % 60;
        int mins = (int)Mathf.Floor(timeInteger / 60);

        watchDisplayText.text = "OKEA is closing in:\n" + mins.ToString();

        if (secs < 10)
        {
            watchDisplayText.text += ":0" + secs.ToString();
        }
        else
        {
            watchDisplayText.text += ":" + secs.ToString();
        }
    }
}
