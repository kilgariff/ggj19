using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class GameHUD : MonoBehaviour
{
    public Text timerText;
    public float timeLeft = 20;

    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        //timeLeft -= Time.deltaTime;
        //int timeInteger = (int)Mathf.Floor(timeLeft);
        //int secs = timeInteger % 60;
        //int mins = (int)Mathf.Floor(timeInteger / 60);
        //if (secs < 10)
        //{
        //    timerText.text = "IKEA\n\n closing\n\n" + mins.ToString() + ":0" + secs.ToString();
        //}
        //else {
        //    timerText.text = "IKEA\n\n closing\n\n" + mins.ToString() + ":" + secs.ToString();
        //}
    }
}
