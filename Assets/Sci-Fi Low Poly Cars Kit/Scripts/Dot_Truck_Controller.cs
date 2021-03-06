using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class Dot_Truck : System.Object
{
	public WheelCollider leftWheel;
	public GameObject leftWheelMesh;
	public WheelCollider rightWheel;
	public GameObject rightWheelMesh;
	public bool motor;
	public bool steering;
	public bool reverseTurn;
    
}

public class Dot_Truck_Controller : MonoBehaviour {

	public List<Dot_Truck> truck_Infos;
	public float maxMotorTorque;
	public float maxSteeringAngle;
    public Joystick myjs;
    float brakeTorque = 0;
    int score = 30;
    public Text text_score;


    public void VisualizeWheel(Dot_Truck wheelPair)
	{
		Quaternion rot;
		Vector3 pos;
		wheelPair.leftWheel.GetWorldPose ( out pos, out rot);
		wheelPair.leftWheelMesh.transform.position = pos;
		wheelPair.leftWheelMesh.transform.rotation = rot;
		wheelPair.rightWheel.GetWorldPose ( out pos, out rot);
		wheelPair.rightWheelMesh.transform.position = pos;
		wheelPair.rightWheelMesh.transform.rotation = rot;
	}
    float steering = 0;
    float motor = 0;
    public void Update()
	{
        /*float motor = maxMotorTorque * Input.GetAxis("Vertical");
		float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
		float brakeTorque = Mathf.Abs(Input.GetAxis("Jump"));*/

      //  float motor = maxMotorTorque * myjs.Vertical;
      //  float steering = maxSteeringAngle * myjs.Horizontal;
        //float brakeTorque = Mathf.Abs(Input.GetAxis("Jump"));

      
        Debug.Log("motor=>>" + motor);
      //  Debug.Log("testbrakeTor=>" + Input.GetAxis("Jump"));
		if (brakeTorque > 0.001) {
			brakeTorque = maxMotorTorque;
			motor = 0;
		} else {
			brakeTorque = 0;
		}

		foreach (Dot_Truck truck_Info in truck_Infos)
		{
			if (truck_Info.steering == true) {
				truck_Info.leftWheel.steerAngle = truck_Info.rightWheel.steerAngle = ((truck_Info.reverseTurn)?1:-1)*steering;
			}

			if (truck_Info.motor == true)
			{
				truck_Info.leftWheel.motorTorque = motor;
				truck_Info.rightWheel.motorTorque = motor;
			}

			truck_Info.leftWheel.brakeTorque = brakeTorque;
			truck_Info.rightWheel.brakeTorque = brakeTorque;

			VisualizeWheel(truck_Info);
		}

	}
    public void brakeUpCar()
    {
        brakeTorque = 0;
    }
    public void brakeDownCar()
    {
        brakeTorque = 1;
    }

    public void right_turn_Up()
    {
        steering = 0;
    }
    public void right_turn_Down()
    {
        steering = -29;
    }
    public void left_turn_Up()
    {
        steering = 0;
    }
    public void left_turn_Dwon()
    {
        steering = 29;

    }

    public void rever_Up()
    {
        motor = 0;
    }
    public void rever_Down()
    {
        motor = -1200;
    }
    public void ahead_Up()
    {
        motor = 0;
    }
    public void ahead_Dwon()
    {
        motor = 1200;

    }
    public void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        score = score + 5;
        text_score.text = "" + score;
        Debug.Log("test triggerEner @D");
    }
   

}