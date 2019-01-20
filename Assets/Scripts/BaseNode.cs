using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DIR { up, right, down, left };
public class BaseNode : MonoBehaviour {

    public string commandType;
    public bool isConnectedLeft;
    public bool isConnectedRight;
  
    public DIR WorldDirections;
    public int magnitude;
    public bool InCanvas = false;

    void ConnectedNode()
    {
        if (true)
        {

        }
    }

    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
