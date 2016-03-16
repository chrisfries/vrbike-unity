using UnityEngine;
using System.Collections;
using System;
using SocketIO;
using SimpleJSON;

public class BikeMovement : MonoBehaviour {

    public bool WebsocketControl;
    public string WebsocketIP;

    public float MotorForce;
    public float SteerForce;
    public WheelCollider FrontWheel;
    public WheelCollider RearWheel;
    public Rigidbody rigidbody;

    private float acceleration = 0;
    private float steeringAngle = 0;

    private SocketIOComponent socket;

	// Use this for initialization
	void Start () { 
        rigidbody.centerOfMass = new Vector3(0f, 0f, -0.1F);

        if (WebsocketControl)
        {
            StartWebsocket();
        }
	}

    void StartWebsocket()
    {
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();


        socket.On("acceleration", OnAcceleration);
        socket.On("steering", OnSteering);
        //socket.On("open", TestOpen);
        /*socket.On("error", TestError);
        socket.On("close", TestClose);*/

    }

    public void OnAcceleration(SocketIOEvent e)
    {
        Debug.Log(e.data);
        JSONNode node = JSON.Parse(e.data + "");
        acceleration = node["acceleration"].AsFloat;
        //Debug.Log(json.GetField("acceleration"));
         
    }

    public void OnSteering(SocketIOEvent e)
    {
        Debug.Log(e.data);
        JSONNode node = JSON.Parse(e.data + "");
        steeringAngle = node["angle"].AsFloat;
        //Debug.Log(json.GetField("acceleration"));

    }


	// Update is called once per frame
	void Update () {
        float v, h;
        if (WebsocketControl)
        {
            v = acceleration  * MotorForce;
            h = steeringAngle;
        }
        else
        {
            v = Input.GetAxis("Vertical") * MotorForce;
            h = Input.GetAxis("Horizontal") * SteerForce;
        }
       
        RearWheel.motorTorque = v;
        FrontWheel.steerAngle = h;

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
      
	}

    void LateUpdate()
    {

    }
}
