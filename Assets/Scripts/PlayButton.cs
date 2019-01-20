using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour {


    public bool playing = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("hands") && !playing)
        {
            playing = true;
            CanvasGrid.instant.StartAvatar();
        }
    }
}
