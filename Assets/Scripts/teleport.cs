using UnityEngine;
using System.Collections;

public class teleport : MonoBehaviour {

    public GameObject TargetObject;

    void OnCollisionEnter(Collision col)
    {
        col.gameObject.transform.position = TargetObject.transform.position;
        col.gameObject.transform.rotation = TargetObject.transform.rotation;

    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
