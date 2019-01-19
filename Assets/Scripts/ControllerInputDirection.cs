using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;
using HoloToolkit.Unity.InputModule;
using UnityEngine.XR;


public class ControllerInputDirection : MonoBehaviour {

    public List<GameObject> directions = new List<GameObject>();
    public int chosenObject;
    public float posValue;

    public void Update()
    {
        var interactionSourceStates = InteractionManager.GetCurrentReading();
        foreach (var interactionSourceState in interactionSourceStates)
        {
            if(interactionSourceState.touchpadPressed)
            {
                if (interactionSourceState.touchpadPosition.x < (-1 * posValue))
                {
                    //pressing left;
                    chosenObject = 4;
                    CreateDirection(chosenObject, interactionSourceState);
                }
                else if (interactionSourceState.touchpadPosition.x > (posValue))
                {
                    //pressing right;
                    chosenObject = 2;
                }
                else if (interactionSourceState.touchpadPosition.y > ( posValue))
                {
                    //pressing up
                    chosenObject = 1;
                }
                else if(interactionSourceState.touchpadPosition.y<(-1*posValue))
                {
                    //pressing down
                    chosenObject = 3;
                }
            }

        }

    }

    public void CreateDirection(int dir, InteractionSourceState sourceState)
    {
        GameObject obj = Instantiate(directions[dir],InputTracking.GetLocalPosition(XRNode.LeftHand),InputTracking.GetLocalRotation(XRNode.LeftHand));

    }


}
