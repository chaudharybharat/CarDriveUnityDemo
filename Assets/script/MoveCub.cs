using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCub : MonoBehaviour {
    private float mooment = 0f;
    public Joystick myjs;
    public float moveSpeed;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        mooment = myjs.Horizontal;
        transform.Translate(Vector3.forward * Time.deltaTime * mooment * moveSpeed);
        //Moves Left and right along x Axis                               //Left/Right
        transform.Translate(Vector3.right * Time.deltaTime * mooment * moveSpeed);
    }
}
