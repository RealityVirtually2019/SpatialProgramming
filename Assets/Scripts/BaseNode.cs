using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DIR { up, right, down, left ,spring};
public class BaseNode : MonoBehaviour {

  //  public string commandType;
 //   public bool isConnectedLeft;
  //  public bool isConnectedRight;
  
    public DIR WorldDirections;
    public int WorldMoveValue;
    public bool InCanvas = false;
    public Vector3 vec;

    public void SetDir (DIR newDirection)
    {
        WorldDirections = newDirection;
        
    }

    public void getpoint()
    {
        vec = transform.position;
    }

    public void SetValue (int newValue)
    {
        newValue = WorldMoveValue;
    }
}
