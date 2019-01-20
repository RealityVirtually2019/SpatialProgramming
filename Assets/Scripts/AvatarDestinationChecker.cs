using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarDestinationChecker : MonoBehaviour {

    public static AvatarDestinationChecker instant;
    public bool HaveAvatar = false;

    private void Awake()
    {
        instant = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        HaveAvatar = true;
    }

}
