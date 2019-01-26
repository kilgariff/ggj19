using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchyGuy : MonoBehaviour
{
    public Rigidbody rb;

    private bool onGround = false;
    private float speed = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        onGround = true;
    }

    void FixedUpdate()
    {
        Vector3 forward = transform.forward;

        if (onGround)
        {
            rb.velocity = new Vector3(-forward.x * speed, rb.velocity.y, -forward.z * speed);
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
    }
}
