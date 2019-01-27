using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.WSA.Input;

public class Hands : MonoBehaviour
{
    public GameLogic gameLogic = null;

    public GameObject leftHandSource = null;
    public GameObject rightHandSource = null;

    GameObject leftHand = null;
    GameObject rightHand = null;

    int Idle = Animator.StringToHash("Idle");
    int GrabSmall = Animator.StringToHash("GrabSmall");

    // Start is called before the first frame update
    void Start()
    {
    }

    void UpdateGrip(GameObject hand, float triggerValue)
    {
        if (hand != null)
        {
            // Animation:

            Animator anim;
            anim = hand.GetComponent<Animator>();

            if (triggerValue >= 0.5f)
            {
                anim.SetTrigger(GrabSmall);
            }
            else
            {
                anim.SetTrigger(Idle);
            }

            // Selection:

            if (triggerValue >= 0.5f)
            {
                HandCollisionTracker hct = hand.GetComponent<HandCollisionTracker>();
                if (hct != null)
                {
                    if (hct.hovering != null)
                    {
                        // Always put watch on left hand.
                        gameLogic.SelectItem(leftHand, hct.hovering);
                    }

                    hct.hovering = null;
                }
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        var interactionSourceStates = InteractionManager.GetCurrentReading();
        foreach (var interactionSourceState in interactionSourceStates)
        {
            var handedness = interactionSourceState.source.handedness;
            GameObject hand = null;

            if (handedness == InteractionSourceHandedness.Left)
            {
                hand = leftHand;
            }
            else if (handedness == InteractionSourceHandedness.Right)
            {
                hand = rightHand;
            }

            if (interactionSourceState.selectPressed)
            {
                UpdateGrip(hand, 1.0f);
            }
            else
            {
                UpdateGrip(hand, 0.0f);
            }

            var sourcePose = interactionSourceState.sourcePose;

            Vector3 sourceGripPosition;
            Quaternion sourceGripRotation;

            if ((sourcePose.TryGetPosition(out sourceGripPosition, InteractionSourceNode.Grip)) &&
                 (sourcePose.TryGetRotation(out sourceGripRotation, InteractionSourceNode.Grip)))
            {
                if (handedness == InteractionSourceHandedness.Left)
                {
                    if (leftHand == null)
                    {
                        leftHand = Object.Instantiate(leftHandSource, transform.parent.parent);
                    }

                    leftHand.transform.localPosition = sourceGripPosition;
                    leftHand.transform.localRotation = sourceGripRotation;
                }
                else if (handedness == InteractionSourceHandedness.Right)
                {
                    if (rightHand == null)
                    {
                        rightHand = Object.Instantiate(rightHandSource, transform.parent.parent);
                    }

                    rightHand.transform.localPosition = sourceGripPosition;
                    rightHand.transform.localRotation = sourceGripRotation;
                }
            }
        }
    }
}
