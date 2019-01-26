using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.WSA.Input;

public class XRController : MonoBehaviour
{
    GameObject leftHand = null;
    GameObject rightHand = null;

    // Start is called before the first frame update
    void Start()
    {
        leftHand = this.gameObject.transform.GetChild(1).gameObject;
        rightHand = this.gameObject.transform.GetChild(2).gameObject;

        if (XRDevice.SetTrackingSpaceType(TrackingSpaceType.Stationary))
        {
            Debug.Log("XRSetup: 'Stationary' was set successfully");
        }
        else
        {
            Debug.LogError("XRSetup: 'Stationary' was not set successfully!");
        }
    }

    // Update is called once per frame
    void Update()
    {
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
                }
                else if (handedness == InteractionSourceHandedness.Right)
                {
                    rightHand.transform.position = sourceGripPosition;
                    rightHand.transform.rotation = sourceGripRotation;
                }

            }
        }
    }
}
