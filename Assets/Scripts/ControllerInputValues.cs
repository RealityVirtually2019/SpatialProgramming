using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;
using HoloToolkit.Unity.InputModule;
using UnityEngine.XR;
using UnityEngine.UI;


public class ControllerInputValues : MonoBehaviour {

    float chosenNum = 0;
  //  public List<GameObject> NumObj = new List<GameObject>();
    public GameObject NumNode;
    public Transform CreatePoint;
    public GameObject createUI;
    // Use this for initialization

    void Start()
    {
        InteractionManager.InteractionSourcePressed += (evt) =>
        {
            if (evt.pressType != InteractionSourcePressType.Touchpad) return;
            if (evt.state.source.handedness != InteractionSourceHandedness.Right) return;
            Vector3 position;
            evt.state.sourcePose.TryGetPosition(out position);
            Quaternion rotation;
            evt.state.sourcePose.TryGetRotation(out rotation);
           CreateNumObj(evt.state);
        };
    }





    // Update is called once per frame
    void Update()
    {

      
    }

    void CreateNumObj(InteractionSourceState state)
    {
        float touchangle = Vector2.SignedAngle(Vector2.up, state.touchpadPosition);

        if (touchangle > 0)
        {
            touchangle *= -1;
            touchangle += 360;
        }
        else
        {
            touchangle *= -1;
        }
        chosenNum = Mathf.Floor(touchangle / 36f);
        // print("num is: " + chosenNum);

        GameObject obj = Instantiate(NumNode, CreatePoint.position,Quaternion.identity);
        BaseNode node = obj.GetComponent<BaseNode>();
        Text text = obj.GetComponentInChildren<Text>();
        text.text = chosenNum.ToString();
        node.WorldMoveValue = (int)chosenNum;
    }
}
