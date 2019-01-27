using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollisionTracker : MonoBehaviour
{
    public GameObject hovering = null;

    private void OnTriggerEnter(Collider other)
    {
        hovering = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (hovering == other.gameObject)
        {
            hovering = null;
        }
    }
}
