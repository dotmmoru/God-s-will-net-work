using UnityEngine;
using System.Collections;

public class camera_photon : Photon.MonoBehaviour
{

	// Use this for initialization
	void Start () {
        if (!photonView.isMine)
        {
            gameObject.active = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
