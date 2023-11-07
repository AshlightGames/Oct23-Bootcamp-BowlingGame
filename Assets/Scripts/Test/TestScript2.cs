using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class TestScript2 : MonoBehaviour
{
    [HideInInspector]
    public string displayNewText;

    [SerializeField]
    string displayText = "Game Started!";

    public Transform testCube;

    public float rotateSpeed;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(displayText);

        int i = 5;

        if (i == 5 || i == 3)
        {
            Debug.Log("Value of i is 5");
        }
        else
        { 
            Debug.Log("Value of i is not 5");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.up);

       // testCube.Rotate(new Vector3(0, 1, 0));

       //testCube.Rotate(new Vector3(0, 1, 0) * rotateSpeed *Time.deltaTime)
        testCube.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        //testCube.Rotate(Vector3.up * rotateSpeed * Input.GetAxis("Mouse X")); Mouse movement
        testCube.Rotate(Vector3.up * rotateSpeed * Input.GetAxis("Horizontal")); //arrow keys
       //testCube.rotation

      //testCube.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if(Input.GetKey(KeyCode.A))
        {
            Debug.Log("A is being pressed");
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space Bar is being pressed");
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            Debug.Log("C is being released");
        }
    }
}
