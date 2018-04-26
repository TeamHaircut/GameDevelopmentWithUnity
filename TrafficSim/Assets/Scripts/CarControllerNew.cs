using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerNew : MonoBehaviour {

    public float speed;
    private bool hasStopped;

	// Use this for initialization
	void Start () {
        hasStopped = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = transform.right * speed;
        Accelerate();
        Debug.Log(speed, gameObject);
    }

    void OnTriggerStay(Collider other)
    {
        //Debug.Log("inside", gameObject);
        if(other.gameObject.CompareTag("StopZone") && hasStopped == false)
        {
            //decelerate
            if (speed < 0)
            {
                speed = speed + 0.01f;
            }
            if (speed <= 0.010 && speed >= 0)
            {
                hasStopped = true;
                //yield return new WaitForSeconds(10000);
                Debug.Log(hasStopped, gameObject);
            }
        }

        
    }

    void Accelerate()
    {
        if (hasStopped == true && speed > -1.3)
        {
            speed = speed - 0.01f;
        }
    }

    /*
    void OnTriggerStay(Collider other)
    {
        Debug.Log("inside", gameObject);
        
        if (other.gameObject.CompareTag("StopZone") && hasStopped == false)
        {
            //decelerate
            if (speed < 0)
            {
                speed = speed + 0.01f;
                GetComponent<Rigidbody>().velocity = transform.forward * speed;
                Debug.Log("speed" + speed, gameObject);
            }
            //stop
            if (speed <= 0.010 && speed >= 0)
            {
                hasStopped = true;
                //yield return new WaitForSeconds(10000);
                Debug.Log(hasStopped, gameObject);
            }

        }
        */
    //}
}
