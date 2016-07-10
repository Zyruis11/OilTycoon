using UnityEngine;
using System.Collections;

public class BuildingPlacement : MonoBehaviour
{
    public GameObject[] buildings;
    public int[] buildingsCost; 
    public static int index = 0;
    public Material hoverMat, standardMat;
    bool builtOn;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            index = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            index = 1;
        }
    }

    void OnMouseUpAsButton()
    {
        if (!builtOn)
        {
            if (buildingsCost[index] <= PlayerStats._Money)
            {
                PlayerStats._Money -= buildingsCost[index];
                GameObject g = (GameObject)Instantiate(buildings[index]);
                g.transform.position = transform.position + Vector3.up;
                builtOn = true;
            } 
            else
            {
                Debug.Log("Not Enough Money");
            }
        }
        else
        {
            Debug.Log("Something is already built on this position");
        }
    }

    #region Mouse Hover 
    void OnMouseOver()
    {
        MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
        mr.material = hoverMat;
    }

    void OnMouseExit()
    {
        MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
        mr.material = standardMat;
    }
    #endregion Mouse Hover
}

