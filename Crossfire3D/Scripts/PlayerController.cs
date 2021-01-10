using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float InterpolationRatio = 0.1f;
    public int ballSpeed = 1000;
    public GameObject ball;
    public GameObject nozzle;

    private Rigidbody rb;

    private float movementX;
    private float movementY;
    private InputAction fireAction;

    private void Awake()
    {
        var actions = GetComponent<PlayerInput>().actions;
        fireAction = actions.FindAction("Fire");
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnFire()
    {
        GameObject bullet = Instantiate(ball, nozzle.transform.position, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(nozzle.transform.forward * ballSpeed);
    }



    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void Update()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), InterpolationRatio);
    }

    private void FixedUpdate()
    {
        //rb.AddForce(movement * speed);
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log("Here");
        //    GameObject bullet = Instantiate(ball, transform.position, Quaternion.identity) as GameObject;
        //    bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 10);
        //}
    }

}
