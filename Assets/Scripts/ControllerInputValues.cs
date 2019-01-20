using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;
using HoloToolkit.Unity.InputModule;
using UnityEngine.XR;


public class ControllerInputValues : MonoBehaviour {

    float chosenNum = 0;
    public List<GameObject> NumObj = new List<GameObject>();
    public Transform CreatePoint;
    public GameObject createUI;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        var interactionSourceStates = InteractionManager.GetCurrentReading();
        foreach (var interactionSourceState in interactionSourceStates)
        {
            if(interactionSourceState.touchpadTouched)
            {
              //  createUI.SetActive(true);
            }else
            {
             //   createUI.SetActive(false);
            }

            if (interactionSourceState.touchpadPressed)
            {
                float touchangle = Vector2.SignedAngle(Vector2.up, interactionSourceState.touchpadPosition);

                if(touchangle>0)
                {
                    touchangle *= -1;
                    touchangle += 360;
                }else
                {
                    touchangle *= -1;
                }
                chosenNum = Mathf.Floor(touchangle / 36f);
               // print("num is: " + chosenNum);
            }
        }
    }

    void CreateNumObj()
    {
        GameObject obj = Instantiate(NumObj[(int)chosenNum], CreatePoint.position, InputTracking.GetLocalRotation(XRNode.RightHand));
    }
}
