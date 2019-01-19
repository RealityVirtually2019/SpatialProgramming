using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGrid : MonoBehaviour {

    public static CanvasGrid instant;

    public List<dir> directions = new List<dir>();
    public List<int> dirValue = new List<int>();
    public GameObject ProgAvatar;



    private void Awake()
    {
        instant = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("directions"))
        {
            directions.Add(other.GetComponent<BaseNode>().WorldDirections);
        }
        else
        {
            dirValue.Add(other.GetComponent<BaseNode>().magnitude);
        }
    }

    public void StartAvatar()
    {
        foreach (int element in dirValue)
        {
            for (int i =1;i<=dirValue.Count;i++)
            {
                ProgAvatar.transform.Translate(Vector3.forward);
            }
        }
    }
}
