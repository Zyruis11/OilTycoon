using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkController : MonoBehaviour
{
    [SerializeField]
    int chunkSize;
    [SerializeField]
    Ground groundObject; 


	// Use this for initialization
	void Start ()
    {
        GenerateMap();
	}
	
    /// <summary>
    /// Generates the playing field
    /// It takes the ChunkSize given and generates the map in both the x and z direction. e.g. 10 chunkSize = 100 points
    /// </summary>
    void GenerateMap()
    {
        Vector3 spawnPosition;
        for (int x = 0; x <= chunkSize; x++)
        {
            for(int y = 0; y <= chunkSize; y++)
            {
                Instantiate(groundObject, spawnPosition = new Vector3(x, 0, y), transform.rotation);
            }
        }
    }

}
