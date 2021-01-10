using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 myVector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if(horizontal <0)
        {
            myVector = new Vector3(-1.0f, 0.0f, 0.0f);
        }
        else if(horizontal >0)
        {
            myVector = new Vector3(1.0f, 0.0f, 0.0f);
        }
        else
        {
            myVector = new Vector3(0.0f, 0.0f, 0.0f);
        }

        if (Input.GetKey("left")||Input.GetKey("right"))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(myVector), 0.035f);
        }

        Debug.Log(horizontal);
    }
}
