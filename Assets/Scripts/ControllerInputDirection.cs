using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;
using HoloToolkit.Unity.InputModule;
using UnityEngine.XR;



public class ControllerInputDirection : AttachToController {

    //public void Awake()
    //{
    //    OnAttachToController();
    //}

    //protected override void OnAttachToController()
    //{
    //    InteractionManager.InteractionSourceUpdated += InterActionSourceUpdated;
    //}

    //private void InterActionSourceUpdated(InteractionSourceUpdatedEventArgs obj)
    //{
    //    if (obj.state.source.handedness == InteractionSourceHandedness.Left && obj.state.touchpadPressed)
    //    {
    //        if (Makeblock)
    //        {
    //            Makeblock = false;
    //            CreateObjectWithDirection(obj.state, createLoc.position, createLoc.rotation);
    //        }
    //        StartCoroutine(QuickWait());
    //    }
    //}


    //IEnumerator QuickWait()
    //{
    //    yield return new WaitForSeconds(2f);
    //    Makeblock = true;
    //}

    public List<GameObject> directions = new List<GameObject>();
    public DIR chosenObject;
    public float posValue;
    public GameObject createUI;
    public Transform createLoc;
    bool Makeblock = true;


    void Start()
    {
        InteractionManager.InteractionSourcePressed += (evt) =>
        {
            if (evt.pressType != InteractionSourcePressType.Touchpad) return;
            if (evt.state.source.handedness != InteractionSourceHandedness.Left) return;
            Vector3 position;
            evt.state.sourcePose.TryGetPosition(out position);
            Quaternion rotation;
            evt.state.sourcePose.TryGetRotation(out rotation);
            CreateObjectWithDirection(evt.state);
        };
    }

    void CreateObjectWithDirection(InteractionSourceState state)
    {
        int tempInt = 0;

        if (state.touchpadPosition.x < (-1 * posValue))
        {
            //pressing left;
            chosenObject  = DIR.left;
            tempInt = 3;
        }
        else if (state.touchpadPosition.x > (posValue))
        {
            //pressing right;
            chosenObject = DIR.right;
            tempInt = 1;
        }
        else if (state.touchpadPosition.y > (posValue))
        {
            //pressing up
            chosenObject = DIR.up;
            tempInt = 0;
        }
        else if (state.touchpadPosition.y < (-1 * posValue))
        {
            //pressing down
            chosenObject = DIR.down;
            tempInt = 2;
        }
      GameObject obj =  Instantiate(directions[tempInt], createLoc.position,directions[tempInt].transform.rotation);
        BaseNode node = obj.GetComponent<BaseNode>();
        node.WorldDirections = chosenObject;
    }

    //public bool Visible()
    //{
    //    get{ return visible; }
    //    set
    //        {
    //        if (value)
    //        {
    //            lastTimeVisible = Time.unscaledTime;
    //        }
    //    }
    //}

    //protected override void OnAttachToController()
    //{
    //    InteractionManager.InteractionSourceUpdated += InteractionSourceUpdated;
    //}

    //protected override void OnDetachFromController()
    //{
    //    Visible = false;
    //    InteractionManager.InteractionSourceUpdated -= InteractionSourceUpdated;
    //}

    //private void InteractionSourceUpdated(InteractionSourceUpdatedEventArgs obj)
    //{
    //    if(obj.state.source.handedness == handedness && obj.state.touchpadTouched)
    //    {
    //        Visible = true;
    //        SelectorPos = obj.state.touchpadPosition;

    //    }
    //}

    //public void Update()
    //{
    //   // if (interactionSourceState.touchpadTouched)
    //  // {

    //        //  createUI.SetActive(true);
    //   // }
    //  //  else
    //  //  {

    //        //   createUI.SetActive(false);
    // //   }

    //}



    //public int TouchLoc(MotionControllerInfo info)
    //{
    //    var source = InteractionManager.GetCurrentReading();



    //    if (interactionSourceState.touchpadPosition.x < (-1 * posValue))
    //    {
    //        //pressing left;
    //        chosenObject = 3;
    //        CreateDirection(chosenObject, interactionSourceState);
    //    }
    //    else if (interactionSourceState.touchpadPosition.x > (posValue))
    //    {
    //        //pressing right;
    //        chosenObject = 1;
    //        CreateDirection(chosenObject, interactionSourceState);
    //    }
    //    else if (interactionSourceState.touchpadPosition.y > (posValue))
    //    {
    //        //pressing up
    //        chosenObject = 0;
    //        CreateDirection(chosenObject, interactionSourceState);
    //    }
    //    else if (interactionSourceState.touchpadPosition.y < (-1 * posValue))
    //    {
    //        //pressing down
    //        chosenObject = 2;
    //        CreateDirection(chosenObject, interactionSourceState);
    //    }

    //    return chosenObject;

    //}

}
