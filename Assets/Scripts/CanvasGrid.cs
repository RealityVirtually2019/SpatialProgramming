using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGrid : MonoBehaviour {

    public static CanvasGrid instant;

    public List<DIR> directions = new List<DIR>();
    public List<int> dirValue = new List<int>();
    public GameObject ProgAvatar;
    public Vector3 AvatarStartPos;


    private void Awake()
    {
        instant = this;
        AvatarStartPos = ProgAvatar.transform.position;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        BaseNode node = other.GetComponent<BaseNode>();

        if (other.CompareTag("directions"))
        {
            directions.Add(other.GetComponent<BaseNode>().WorldDirections);
            node.InCanvas = true;
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
                ProgAvatar.transform.Translate(AvatarPusher(directions[element]));
            }
        }
    }

    IEnumerator WhereAvatar()

    {
        yield return new WaitForSeconds(1f);
        if(!AvatarDestinationChecker.instant.HaveAvatar)
        {
            yield return new WaitForSeconds(2f);
            ProgAvatar.transform.position = AvatarStartPos;
        }
        else
        {
            //experience is ended
        }

    }

    public Vector3 AvatarPusher( DIR gowhere)
    {
        Vector3 vec = new Vector3();

        switch(gowhere)
        {
            case DIR.up:
                vec = Vector3.forward;
                break;
            case DIR.right:
                vec = Vector3.right;
                break;
            case DIR.down:
                vec = -Vector3.up;
                break;

            case DIR.left:
                vec = -Vector3.right;
                break;

        }

        return vec;
    }
}
