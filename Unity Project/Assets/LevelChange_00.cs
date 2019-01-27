using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChange_00 : MonoBehaviour
{
    bool introScene = true;
    float timer4Flasher=600;
    public GameObject flashyText;
    public GameObject[] animTiles;
    private int sceneNum = 0;
    public bool textEnabled = true;

    Animator anim;

    //// Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (textEnabled)
        {
            timer4Flasher += Time.deltaTime;
            if (timer4Flasher >= 0.5f)
            {
                timer4Flasher = 0;
                flashyText.SetActive(!flashyText.activeSelf);
            }
        }
        

        if (Input.GetKeyDown("space")) {

            animTiles[sceneNum].SetActive(false);
            sceneNum++;
            if (sceneNum==1) {
                textEnabled = false;
                flashyText.SetActive(false);
                if (introScene) {
                    //SceneManager()
                }

            }
        }


    }
}
