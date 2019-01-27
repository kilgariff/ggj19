using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class autoLevelChange00 : MonoBehaviour
{

    float timer = 60;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer<= 0) {
            SceneManager.LoadScene("gameOntro_00");
        }
    }
}
