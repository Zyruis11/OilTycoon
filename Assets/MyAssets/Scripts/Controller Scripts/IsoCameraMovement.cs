using UnityEngine;
using System.Collections;

public class IsoCameraMovement : MonoBehaviour
{
    //TODO: Max boundaries 
    public GameObject placeholder;
    public Camera camera;
    public int movementModifier;
    public float rotationSpeed;
    public float maxX, minX, maxY, minY, maxZ, minZ; 
  
	//Function that is called every frame
	void Update ()
    {
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(transform.position.x, minX, maxX);
        clampedPosition.z = Mathf.Clamp(transform.position.z, minZ, maxZ);
        transform.position = clampedPosition;
        CameraMovement();
        
    }

    #region CameraMovement
    /// <summary>
    /// Function for managing camera movement.
    /// This function handles mouse camera movement(Shifts the camara when the mouse is pushed towards the edge of the screen) 
    /// This function also handles moving the camera with the keyboard(WASD keys)
    /// This function also features a zoom feature that is bound to the scroll wheel
    /// </summary>
    void CameraMovement()
    {
        float translationX = Input.GetAxis("Horizontal");
        float translationY = Input.GetAxis("Vertical");
        float fastTranslationX = movementModifier * Input.GetAxis("Horizontal");
        float fastTranslationY = movementModifier * Input.GetAxis("Vertical");
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(fastTranslationX + fastTranslationY, 0, fastTranslationY - fastTranslationX);
        }
        else
        {
            //transform.Translate(translationX + translationY, 0, translationY - translationX);
        }

        //mouse scrolling
        float mousePosX = Input.mousePosition.x;
        float mousePosY = Input.mousePosition.y;
        int scrollDistance = 5;
        float scrollSpeed = 70;

        //Horizontal camera movement
        if (mousePosX < scrollDistance) //Left Movement
        {
            transform.Translate(-1, 0, 1);
        }

        if (mousePosX >= Screen.width - scrollDistance) //Right Movement 
        {
            transform.Translate(1, 0, -1);
        }

        //Vertical camera movement
        if (mousePosY < scrollDistance)
        {
            transform.Translate(-1, 0, -1);
        }

        //Camera Rotation 
        if(Input.GetKey(KeyCode.Q))
        {
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.y -= rotationSpeed;
            transform.rotation = Quaternion.Euler(rotationVector);
        }

        if (Input.GetKey(KeyCode.E))
        {
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.y += rotationSpeed;
            transform.rotation = Quaternion.Euler(rotationVector);
        }

        if (mousePosY >= Screen.height - scrollDistance && BoundaryCheck())
        //scrolling up
        { 
            transform.Translate(1, 0, 1);
        }

        Camera cam = GetComponentInChildren<Camera>();
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && cam.orthographicSize > 4)
        {
            cam.orthographicSize = cam.orthographicSize - 4;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && cam.orthographicSize < 12)
        {
            cam.orthographicSize = cam.orthographicSize + 4;
        }

        //default zoom
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            cam.orthographicSize = 8;
        }

        //TODO: Just for debug 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = new Vector3(0, transform.position.y, 0);
        }
    }
    #endregion CameraMovement 

    private bool BoundaryCheck()
    {
        if (transform.position.x < maxX && transform.position.z < maxZ)
        {
            return true;
        }
        else
        {
            return false; 
        }
    }

}

