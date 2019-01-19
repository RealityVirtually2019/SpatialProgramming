using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentFile : MonoBehaviour {

    public string parentName;

    public Vector3 CurrentScale;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("flexer"))
        {
            // change the parent name on the flexer to be parentname
            //set the flex to have this be a parent
        }
    }

    private void Update()
    {
        //set the values of children based on the parent object
    }
}
