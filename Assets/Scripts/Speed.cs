using UnityEngine;
using System.Collections;

public class Speed : MonoBehaviour {

    public GameObject Rigidbody;


	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        float speed = Rigidbody.GetComponent<Rigidbody>().velocity.magnitude * 3.6F;

        GetComponent<TextMesh>().text = System.Math.Round(speed) + "km/h";

	}
}
