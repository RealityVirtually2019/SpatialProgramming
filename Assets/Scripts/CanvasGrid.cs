using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGrid : MonoBehaviour {

    public static CanvasGrid instant;

    public List<DIR> directions = new List<DIR>();
    public List<int> dirValue = new List<int>();
    public GameObject ProgAvatar;
    public Vector3 AvatarStartPos;
    public PlayButton playbutton;

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

            node.getpoint();
            Vector3 vec = node.vec;

            StartCoroutine(GetWhenLoose(vec, node,other.gameObject));
        }
        else if(other.CompareTag("dirvalue"))
        {
            dirValue.Add(other.GetComponent<BaseNode>().WorldMoveValue);
            node.InCanvas = true;

            node.getpoint();
            Vector3 vec = node.vec;
            
            StartCoroutine(GetWhenLoose(vec, node,other.gameObject));
        }

       // other.transform.rotation = transform.rotation;


    //    print("hitting the wall");

    }

    IEnumerator GetWhenLoose(Vector3 point, BaseNode node, GameObject obj
        )
    {
        obj.GetComponent<Collider>().enabled = false;

        while (node.transform.parent!=null)
        {
            yield return new WaitForSeconds(.1f);
        }

        float dis = Vector3.Distance(node.transform.position, point);

        while (dis>.1f)
        {
            node.transform.position = Vector3.MoveTowards(node.transform.position, point, Time.deltaTime);
            dis = Vector3.Distance(node.transform.position, point);
        }
        

    }

    public void StartAvatar()
    {
       

        if(directions.Count<dirValue.Count)
        {
            while(directions.Count<dirValue.Count)
            {
                directions.Add(directions[0]);
            }
        }else if(dirValue.Count<directions.Count)
        {
            while(dirValue.Count < directions.Count)
            {
                int i = Random.Range(0, 9);
                dirValue.Add(i);
            }
        }

        StartCoroutine(MoveAvatar());
    }

    IEnumerator MoveAvatar()
    {
        for(int j=0;j<dirValue.Count;j++)
        {
            for (int i = 0; i < dirValue[j]; i++)
            {
                ProgAvatar.transform.Translate(AvatarPusher(directions[j]));
                yield return new WaitForSeconds(.2f);
            }
        }

        StartCoroutine(WhereAvatar());
    }


    IEnumerator WhereAvatar()

    {
        yield return new WaitForSeconds(1f);
        if(!AvatarDestinationChecker.instant.HaveAvatar)
        {
            yield return new WaitForSeconds(2f);
            ProgAvatar.transform.position = AvatarStartPos;
            playbutton.playing = false;
        }
        else
        {
            //experience is ended
        }

    }

    public Vector3 AvatarPusher( DIR gowhere)
    {
        // button img is from https://www.freeiconspng.com/uploads/play-button-icon-png-2.png


        Vector3 vec = new Vector3();

        Vector3 vecForward = new Vector3(0, 0, .5f);
        Vector3 vecBack = new Vector3(0, 0, -.5f);
        Vector3 vecLeft = new Vector3(-.5f, 0, 0);
        Vector3 vecRight = new Vector3(.5f, 0, 0);

        switch(gowhere)
        {
            case DIR.up:
                vec = vecForward;
                break;
            case DIR.right:
                vec = vecRight;
                break;
            case DIR.down:
                vec = vecBack;
                break;

            case DIR.left:
                vec = vecLeft;
                break;

        }
       
        return vec;
    }
}
