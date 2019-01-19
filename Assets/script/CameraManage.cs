using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManage : MonoBehaviour {

    public Camera[] cames;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void secondCameraOpne()
    {
        Debug.Log("test secondCameraopen");
        cames[0].enabled = false;
        cames[1].enabled = true;
    }
}
