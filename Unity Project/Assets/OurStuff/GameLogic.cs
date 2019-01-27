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

    public void SelectItem(GameObject hand, GameObject item)
    {
        if (item.name == "Watch")
        {
            Debug.Log("Got the watch");
            if (hand != null)
            {
                item.transform.parent = hand.transform;
                item.transform.localPosition = new Vector3(-0.005401689f, 0.031669f, 0.09010f);
                item.transform.localRotation = Quaternion.Euler(-65, 199.482f, -110);
                item.transform.localScale = new Vector3(0.024f, 0.0181f, 0.0253f);
            }
        }
        else if (item.name == "Keys")
        {
            Debug.Log("Got the keys");
        }
        else if (item.name == "Wallet")
        {
            Debug.Log("Got the wallet");
        }
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
