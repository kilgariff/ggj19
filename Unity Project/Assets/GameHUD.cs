using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class GameHUD : MonoBehaviour
{
    public Text timerText;
    public float timeLeft = 900;

    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timerText.text = "IKEA closing:  " + (Mathf.Floor(timeLeft)).ToString();
    }
}
