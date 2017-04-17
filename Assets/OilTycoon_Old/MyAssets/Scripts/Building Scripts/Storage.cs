using UnityEngine;
using System.Collections;

public class Storage : MonoBehaviour
{
    public int storageAmount; 
	// Use this for initialization
	void Start ()
    {
        PlayerStats._OilStorage += storageAmount;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
