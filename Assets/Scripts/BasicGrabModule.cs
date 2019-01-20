using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule.Examples.Grabbables;

public class BasicGrabModule : BaseGrabbable  {

    public Vector3 size;

    public void Awake()
    {
        size = transform.localScale;
    }

    protected override void Update()
    {
        base.Update();
        transform.localScale = size;
    }

    protected override void StartGrab(BaseGrabber grabber)
    {
        base.StartGrab(grabber);
        transform.SetParent(GrabberPrimary.transform);
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    protected override void EndGrab()
    {
        
        transform.SetParent(null);
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        base.EndGrab();
    }

    protected override void AttachToGrabber(BaseGrabber grabber)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        if (!activeGrabbers.Contains(grabber))
            activeGrabbers.Add(grabber);
    }

    protected override void DetachFromGrabber(BaseGrabber grabber)
    {
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().useGravity = false;
    }

}
