using UnityEngine;
using System.Collections;

public class BikeMovementScript : MonoBehaviour {

    public float MotorForce;
    public float SteerForce;
    public WheelCollider FrontWheel;
    public WheelCollider RearWheelL;
    public Rigidbody rigidbody;
    //public WheelCollider RearWheelR;

	// Use this for initialization
	void Start () {
        rigidbody.centerOfMass = new Vector3(0f, 0f, -0.1F);
	}
	
	// Update is called once per frame
	void Update () {

        float v = Input.GetAxis("Vertical") * MotorForce;
        RearWheelL.motorTorque = v;
        //RearWheelR.motorTorque = v;

        float h = Input.GetAxis("Horizontal") * SteerForce;
        FrontWheel.steerAngle = h;

        if (h == 0)
        {
            
        }
        //this.gameObject.transform.rotation.eulerAngles.Set(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y, 0);

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        Debug.Log(this.gameObject.transform.rotation.eulerAngles);

      
	}

    void LateUpdate()
    {

    }
}
