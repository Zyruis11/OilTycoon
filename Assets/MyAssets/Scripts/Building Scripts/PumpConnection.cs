using UnityEngine;
using System.Collections;

public class PumpConnection : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    //NOTE:If Objects are too be detected they have to have a kinematic rigidbody on them
    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Pipe")
        {
            Debug.Log("Touching" + transform.name);
        } 
    }
}
