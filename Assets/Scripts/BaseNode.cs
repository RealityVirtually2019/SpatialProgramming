using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum dir { up, right, down, left };
public class BaseNode : MonoBehaviour {

    public string commandType;
    public bool isConnectedLeft;
    public bool isConnectedRight;
  
    public dir WorldDirections;
    public int magnitude;
    

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
