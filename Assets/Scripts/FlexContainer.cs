using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlexContainer : MonoBehaviour {

    public enum flexscope { pubs,pri};
    public flexscope scope;

    public enum datatype {number, dotnumber, letters, flick};
    public datatype flexdatatype;
    public int num1 = 0;
    public int num2 = 0;

    public string flexname;

    private void Awake()
    {
        switch (flexdatatype)
        {
            case datatype.number:

                break;

            case datatype.dotnumber:

                break;

            case datatype.flick:

                break;

            case datatype.letters:

                break;

        }
    }

    public void ChosenDataType(int num1,int numb2)
    {

    }

}
