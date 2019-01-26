using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float right_trigger = Input.GetAxis("AXIS_10");
        Debug.Log("Right hand trigger axis: " + right_trigger);
    }
}
