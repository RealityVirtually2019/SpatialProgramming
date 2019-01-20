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

    public void SetDir (DIR newDirection)
    {
        WorldDirections = newDirection;
        
    }

    public void SetValue (int newValue)
    {
        newValue = magnitude;
    }
}
