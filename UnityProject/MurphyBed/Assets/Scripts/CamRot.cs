using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamRot : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    public Transform RAround; // a gameobject that is the parent of the camera // you can use for rotation but keep the camera look at X
    public float RotationSpeed = 200f;
    public float scrollSpeed = 2f;
    public float PanSensitivity = 5f;
    Vector3 lastPanPosition;

    // for toggling 
    public GameObject toggle_RCR_Cam;
    public GameObject toggle_RCR_Product;
    public GameObject toggle_RCR_Env;
    public GameObject [] LightingRotating;


    private void Start()
    {

        toggle_RCR_Cam.GetComponent<Toggle>().isOn = true;
        toggle_RCR_Product.GetComponent<Toggle>().isOn = false;
        toggle_RCR_Env.GetComponent<Toggle>().isOn = false;

    }   

    void Update()
    {

            if (Input.GetMouseButton(0))
            {
                if (toggle_RCR_Cam.GetComponent<Toggle>().isOn == true)
                {

                RAround.transform.RotateAround(target.transform.position, Vector3.up, ((Input.GetAxisRaw("Mouse X") * Time.deltaTime) * RotationSpeed));
                RAround.transform.RotateAround(target.transform.position, transform.right, -((Input.GetAxisRaw("Mouse Y") * Time.deltaTime) * RotationSpeed));
                }

                if (toggle_RCR_Product.GetComponent<Toggle>().isOn == true)
                {
      
                    GameObject Product = GameObject.Find("Product");
                    Product.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * -1*10,0), Space.World);
                }
                
                 if (toggle_RCR_Env.GetComponent<Toggle>().isOn == true)
                 {
                    foreach (GameObject x in LightingRotating)
                    {
                        x.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * -1 * 10, 0), Space.World);
                    }
                 }
        }

        // for zooming 
        // see if mouse wheel is used 	
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            // you need add max and min
            float ScrollWheelChange = Input.GetAxis("Mouse ScrollWheel");
            cam.transform.position += cam.transform.forward * ScrollWheelChange * scrollSpeed;

        }
            

        if (Input.GetMouseButtonDown(1))
        {
            lastPanPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(1))
        {
            PanCamera(Input.mousePosition);
        }

    }


    void PanCamera(Vector3 newPanPosition)
    {
        // Determine how much to move the camera
        Vector3 offset = cam.ScreenToViewportPoint(lastPanPosition - newPanPosition);
        Vector3 move = new Vector3(offset.x * PanSensitivity, offset.y * PanSensitivity, 0);

        // Perform the movement
        cam.transform.Translate(move, Space.Self);

        // Cache the position
        lastPanPosition = newPanPosition;
    }


}
