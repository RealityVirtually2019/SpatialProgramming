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
    public GameObject createUI;

    private void Start()
    {
        InteractionManager.InteractionSourcePressed += (evt) =>
        {
            if (evt.pressType != InteractionSourcePressType.Touchpad) return;
            Vector3 position;
            evt.state.sourcePose.TryGetPosition(out position);
            Quaternion rotation;
            evt.state.sourcePose.TryGetRotation(out rotation);
            Instantiate(directions[TouchLoc(evt)], position, rotation);
        };
    }

    public void Update()
    {
       // if (interactionSourceState.touchpadTouched)
      // {

            //  createUI.SetActive(true);
       // }
      //  else
      //  {

            //   createUI.SetActive(false);
     //   }

    }



    public int TouchLoc(interac)
    {
        var source = InteractionManager.GetCurrentReading();
        Input.
        

        if (interactionSourceState.touchpadPosition.x < (-1 * posValue))
        {
            //pressing left;
            chosenObject = 3;
            CreateDirection(chosenObject, interactionSourceState);
        }
        else if (interactionSourceState.touchpadPosition.x > (posValue))
        {
            //pressing right;
            chosenObject = 1;
            CreateDirection(chosenObject, interactionSourceState);
        }
        else if (interactionSourceState.touchpadPosition.y > (posValue))
        {
            //pressing up
            chosenObject = 0;
            CreateDirection(chosenObject, interactionSourceState);
        }
        else if (interactionSourceState.touchpadPosition.y < (-1 * posValue))
        {
            //pressing down
            chosenObject = 2;
            CreateDirection(chosenObject, interactionSourceState);
        }

        return chosenObject;

    }

}
