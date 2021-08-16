using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonCode : MonoBehaviour
{


    [SerializeField] private Camera cam;
    public Transform RAround; 
    public Transform target;

    // For all intial values 
    private Vector3 initPosition;
    private Quaternion initRotationCAM;
    private Quaternion initRotationProduct;
    private Quaternion initRotationLighting;
    

    private GameObject[] DT;
    private GameObject[] toggle;

    // List of object share similar material
    public GameObject[] Gm1;
    public GameObject[] Gm2;

    // Materials to be used for changing
    public Material M1;
    public Material M2;
    public Material M3;
    public Material M4;

    // For object hiding showing 
    public GameObject obj1;
    public GameObject obj2;

    // For environment changing
    public GameObject[] EnvSets;
    public GameObject[] lights;
    public Color CamBG01Color;
    public Color CamBG02Color;

    // For animation play stop
    public Animator AnimationCont;

    public GameObject ExpToggle;
    public GameObject AnimToggle;

    public Color imageColor;
    public GameObject animPanal;
    public GameObject animPlay;
    public GameObject expPanal;
    public GameObject expPlay;


    // Start is called before the first frame update
    void Start()
    {
        // showing the object to start with
        obj1.SetActive(true);
        obj2.SetActive(false);

        // showing the environment to start with
        EnvSets[0].SetActive(true);
        lights[0].SetActive(true);

        // get the intail rotation and position of cam position and RAround rotation
        initPosition = cam.transform.position;
        initRotationCAM = RAround.transform.rotation;
        initRotationProduct = target.transform.rotation;
        initRotationLighting = lights[0].transform.rotation;


    }

    // Update is called once per frame
    void Update()
    {

        // For Animation play stop
        if (AnimToggle.GetComponent<Toggle>().isOn == true)
        {
            AnimationCont.SetBool("AnimPart", true);
            ExpToggle.GetComponent<Toggle>().interactable = false;
            expPanal.GetComponent<Image>().color = imageColor;
            expPlay.GetComponent<Image>().color = imageColor;
        }
        else
        {
            AnimationCont.SetBool("AnimPart", false);
            ExpToggle.GetComponent<Toggle>().interactable = true;
            expPanal.GetComponent<Image>().color = Color.white;
            expPlay.GetComponent<Image>().color = Color.white;
        }
        if (ExpToggle.GetComponent<Toggle>().isOn == true)
        {
            AnimationCont.SetBool("ExpAnim", true);
            AnimToggle.GetComponent<Toggle>().interactable = false;
            animPanal.GetComponent<Image>().color = imageColor;
            animPlay.GetComponent<Image>().color = imageColor;
        }
        else
        {
            AnimationCont.SetBool("ExpAnim", false);
            AnimToggle.GetComponent<Toggle>().interactable = true;
            animPanal.GetComponent<Image>().color = Color.white;
            animPlay.GetComponent<Image>().color = Color.white;
        }

        // to get ESC key and exit the application 
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }


    public void Material_1()
    {
        foreach (GameObject x in Gm1)
        {
            x.GetComponent<Renderer>().material = M1;
        }
    }

    public void Material_2()
    {
        foreach (GameObject x in Gm1)
        {
            x.GetComponent<Renderer>().material = M2;
        }
    }

    public void Color_01()
    {
        foreach (GameObject x in Gm2)
        {
            x.GetComponent<Renderer>().material = M3;
        }
    }

    public void Color_02()
    {
        foreach (GameObject x in Gm2)
        {
            x.GetComponent<Renderer>().material = M4;
        }
    }

    public void Object01()
    {
        obj1.SetActive(true);
        obj2.SetActive(false);
    }

    public void Object02()
    {
        obj1.SetActive(false);
        obj2.SetActive(true);
    }

    public void EnvChange01()
    {
        EnvSets[0].SetActive(true);
        EnvSets[1].SetActive(false);
        lights[0].SetActive(true);
        lights[1].SetActive(false);
        cam.backgroundColor = CamBG01Color;
        DynamicGI.UpdateEnvironment();
    }

    public void EnvChange02()
    {
        EnvSets[0].SetActive(false);
        EnvSets[1].SetActive(true);
        lights[0].SetActive(false);
        lights[1].SetActive(true);
        cam.backgroundColor = CamBG02Color;
        DynamicGI.UpdateEnvironment();
    }


    public void ResetCAM()
    {
        // reset to intial rotation and position
        RAround.transform.rotation = initRotationCAM;
        cam.transform.position = initPosition;
    }

    public void ResetAll()
    {
        // reset cam
        RAround.transform.rotation = initRotationCAM;
        cam.transform.position = initPosition;

        // reset product 
        target.transform.rotation = initRotationProduct;

        // reset lighting 
        foreach (GameObject light in lights)
        {
            light.transform.rotation = initRotationLighting;

        }

        // rest all toggle 
        DT = GameObject.FindGameObjectsWithTag("DToggle");
        foreach (GameObject obj in DT)
        {
            obj.GetComponent<Toggle>().isOn = true;
        }

        toggle = GameObject.FindGameObjectsWithTag("toggle");
        foreach (GameObject obj in toggle)
        {
            obj.GetComponent<Toggle>().isOn = false;
        }
    }

    public void OpenURL()
    {
        Application.OpenURL("https://www.google.com/search?q=murphy+bed");
    }

    public void exit()
    {
        Application.Quit();
    }
}
