using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    public static int _Oil;
    public static int _OilStorage; 
    public static float _Money; 

    // Use this for initialization
    void Start()
    {
        //TODO: Change this when saved games are implemented
        _Money = 2000;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Total Oil: " + _Oil + " Total Storage: " + _OilStorage + " Total Money: " + _Money);
    }
}
  
