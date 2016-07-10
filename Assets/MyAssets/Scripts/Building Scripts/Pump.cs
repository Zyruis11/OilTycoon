using UnityEngine;
using System.Collections;

public class Pump : MonoBehaviour
{
    public bool isPumping;
    public int cost; 

    // Use this for initialization
    void Start ()
    {
        isPumping = true;
        StartCoroutine(AddPoints());
	}

    // Update is called once per frame
    void Update()
    {
        //Checks if the pump isn't pumping and checks to see if it should be
        //If True it starts the pump up again automatically
        if (isPumping == false && PlayerStats._OilStorage > PlayerStats._Oil)
        {
            isPumping = true;
            StartCoroutine(AddPoints());
        }
    }

    //Adds points over time
    IEnumerator AddPoints()
    {
        while (isPumping)
        {
            if (PlayerStats._OilStorage > PlayerStats._Oil)
            {
                Debug.Log("Is Pumping");
                PlayerStats._Oil += 1;
                yield return new WaitForSeconds(1);
            }
            else if(PlayerStats._OilStorage <= PlayerStats._Oil)
            {
                Debug.Log("Stopping The Pump... " + transform.name);
                isPumping = false; 
            }
        }
    }
}
