﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCar : MonoBehaviour {


    public Transform[] wheels;
    public float motorPower = 150.0f;
    public float maxTurn = 25.0f;

    float wheelTurn = 0.0f;
    float intantePower = 0.0f;
    float brake = 0.0f;
    Rigidbody myrigidbody;
	// Use this for initialization
	void Start () {
        myrigidbody = this.gameObject.GetComponent<Rigidbody>();
        myrigidbody.centerOfMass = new Vector3(0f, 0f, 0.0f);
	}

     void FixedUpdate()
    {
        Debug.Log("test=>>>>>>>>>");
        intantePower = Input.GetAxis("Vertical") * motorPower * Time.deltaTime;
        wheelTurn = Input.GetAxis("Horizontal") * maxTurn;
        brake = Input.GetKey("space") ? myrigidbody.mass * 0.1f : 0.0f;
        ///turn collider
        getCollider(0).steerAngle = wheelTurn;
        getCollider(1).steerAngle = wheelTurn;

        //turn wheels
        wheels[0].localEulerAngles = new Vector3(wheels[0].localEulerAngles.x,
            getCollider(0).steerAngle - wheels[0].localEulerAngles.z + 90,
            wheels[0].localEulerAngles.z);

        wheels[1].localEulerAngles = new Vector3(wheels[1].localEulerAngles.x,
           getCollider(1).steerAngle - wheels[1].localEulerAngles.z + 90,
           wheels[1].localEulerAngles.z);

        //spin wheel
        wheels[0].Rotate(0, -getCollider(0).rpm / 60 * 360 * Time.deltaTime, 0);
        wheels[1].Rotate(0, -getCollider(1).rpm / 60 * 360 * Time.deltaTime, 0);
        wheels[2].Rotate(0, -getCollider(2).rpm / 60 * 360 * Time.deltaTime, 0);
        wheels[3].Rotate(0, -getCollider(3).rpm / 60 * 360 * Time.deltaTime, 0);

        //brakes
        if (brake > 0.0f)
        {
            getCollider(0).brakeTorque = brake;
            getCollider(1).brakeTorque = brake;
            getCollider(2).brakeTorque = brake;
            getCollider(3).brakeTorque = brake;
            getCollider(2).brakeTorque = 0.0f;
            getCollider(3).brakeTorque = 0.0f;
        }
        else
        {
            getCollider(0).brakeTorque = 0.0f;
            getCollider(1).brakeTorque = 0.0f;
            getCollider(2).brakeTorque = 0.0f;
            getCollider(3).brakeTorque = 0.0f;
            getCollider(2).brakeTorque =intantePower;
            getCollider(3).brakeTorque = intantePower;
        }
    }

    WheelCollider getCollider(int n)
    {
        return wheels[n].gameObject.GetComponent<WheelCollider>();
    }
    // Update is called once per frame
   
}
