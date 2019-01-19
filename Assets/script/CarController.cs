using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    public WheelCollider TireFR;
    public WheelCollider TireFL;
    public WheelCollider TireRR;
    public WheelCollider TireRL;
    public float MaxSpeed = 500;
    public float angle = 40;
    public Transform CenterOfGravity;
    public Transform TireTransformFR;
    public Transform TireTransformFL;
    public Transform TireTransformRR;
    public Transform TireTransformRL;
    Rigidbody rb;
    float wheelTurn = 0.0f;
    float brake = 0.0f;
    public Joystick myjs;
    //public Joystick myjs_turn;
    float intantePower = 0.0f;
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = CenterOfGravity.localPosition;
       // rb.centerOfMass = new Vector3(0f, 0f, 0.0f);
    }
    void Update()
    {
        TireTransformFL.Rotate(TireFL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        TireTransformFR.Rotate(TireFR.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        TireTransformRL.Rotate(TireRL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        TireTransformRR.Rotate(TireRR.rpm / 60 * 360 * Time.deltaTime, 0, 0);
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {

       
    intantePower = myjs.Vertical * MaxSpeed *Time.deltaTime;
       // brake = Input.GetKey("space") ? rb.mass * 0.1f : 0.0f;
        brake = 0;
        if (Input.GetKey(KeyCode.Space) == true)
        {
            Debug.Log("break==<>>>");
           
          //  TireRL.motorTorque = -1000 * 100;
           // TireFR.motorTorque = -1000 * 100;
           // TireRR.motorTorque = -1000 * 100;
           // TireFL.motorTorque = -1000 * 100;
        }
        /*    Debug.Log("test brack" + brake);
          //  brakes
              if (brake > 0.0f)
              {
                  TireFR.brakeTorque = brake;
                  TireFL.brakeTorque = brake;
                  TireRR.brakeTorque = brake;
                  TireRL.brakeTorque = brake;
                  TireRR.brakeTorque = 0.0f;
                  TireRL.brakeTorque = 0.0f;
              }
              else
              {
                  TireFR.brakeTorque = 0.0f;
                  TireFL.brakeTorque = 0.0f;
                  TireRR.brakeTorque = 0.0f;
                  TireRL.brakeTorque = 0.0f;
                  TireRL.brakeTorque = intantePower;
                  TireRL.brakeTorque = intantePower;
              }
              */


        TireRR.motorTorque = MaxSpeed * myjs.Vertical;
        TireRL.motorTorque = MaxSpeed * myjs.Vertical;

        //turn
        wheelTurn = myjs.Horizontal;

     
        TireFL.steerAngle = angle * wheelTurn;
        TireFR.steerAngle = angle * wheelTurn;

       // TireRR.steerAngle = angle * wheelTurn;
       // TireRL.steerAngle = angle * wheelTurn;

        TireTransformFL.localEulerAngles = new Vector3(TireTransformFL.localEulerAngles.x,
        TireFL.steerAngle - TireTransformFL.localEulerAngles.z ,
          TireTransformFL.localEulerAngles.z);

        TireTransformFR.localEulerAngles = new Vector3(TireTransformFR.localEulerAngles.x,
          TireFR.steerAngle - TireTransformFR.localEulerAngles.z,
          TireTransformFR.localEulerAngles.z);

      
        
        ApplyLocalPositionToVisuals(TireFL);
        ApplyLocalPositionToVisuals(TireFR);
        ApplyLocalPositionToVisuals(TireRL);
        ApplyLocalPositionToVisuals(TireRR);
    }
   public void acceleterRemoter()
    {
        float x = Input.acceleration.x;
        if (x < -0.1f)
        {
            MoveLeft();
        }else if (x > 0.1f)
        {
            MoveRight();
        }
        else
        {

        }

    }
    public void MoveLeft()
    {

    }

    public void MoveRight()
    {

    }
}
