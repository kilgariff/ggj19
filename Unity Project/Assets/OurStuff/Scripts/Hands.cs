using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.WSA.Input;

public class Hands : MonoBehaviour
{
    public GameObject leftHandSource = null;
    public GameObject rightHandSource = null;

    GameObject leftHand = null;
    GameObject rightHand = null;

    Animator anim;

    int Idle = Animator.StringToHash("Idle");
    int GrabLarge = Animator.StringToHash("GrabLarge");

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        leftHand = Object.Instantiate(leftHandSource, this.transform);
        rightHand = Object.Instantiate(rightHandSource, this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        float right_trigger = Input.GetAxis("AXIS_10");
        Debug.Log("Right hand trigger axis: " + right_trigger);

        var interactionSourceStates = InteractionManager.GetCurrentReading();
        foreach (var interactionSourceState in interactionSourceStates)
        {
            var sourcePose = interactionSourceState.sourcePose;
            Vector3 sourceGripPosition;
            Quaternion sourceGripRotation;

            if ((sourcePose.TryGetPosition(out sourceGripPosition, InteractionSourceNode.Grip)) &&
                 (sourcePose.TryGetRotation(out sourceGripRotation, InteractionSourceNode.Grip)))
            {
                var handedness = interactionSourceState.source.handedness;

                if (handedness == InteractionSourceHandedness.Left)
                {
                    leftHand.transform.position = sourceGripPosition;
                    leftHand.transform.rotation = sourceGripRotation;

                    Debug.Log("Left hand position: " + leftHand.transform.position);
                }
                else if (handedness == InteractionSourceHandedness.Right)
                {
                    rightHand.transform.position = sourceGripPosition;
                    rightHand.transform.rotation = sourceGripRotation;

                    Debug.Log("Right hand position: " + rightHand.transform.position);
                }

            }
        }
    }
}
