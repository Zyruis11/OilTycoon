using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

   // public GameObject groundObject;

    [SerializeField]
    int oilValue;

    [SerializeField]
    bool builtOn; 
  
	// Use this for initialization
	void Start ()
    {
        builtOn = false; 
        oilValue = Mathf.FloorToInt(Random.Range(0, 100)); 
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
